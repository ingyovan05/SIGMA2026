using System.Security.Claims;
using System.Text.RegularExpressions;
using Dapper;
using Ismocol.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/special-reports")]
public sealed partial class SpecialReportsController(ISqlConnectionFactory connectionFactory) : ControllerBase
{
    [HttpGet("types")]
    public async Task<IActionResult> Types()
    {
        const string sql = """
            SELECT CODIGOTIPOCONSULTA AS Id,
                LTRIM(RTRIM(NOMBRETIPOCONSULTA)) AS Name
            FROM dbo.ListaTipoConsulta()
            ORDER BY NOMBRETIPOCONSULTA;
            """;
        await using var connection = connectionFactory.Create();
        return Ok(await connection.QueryAsync<ReportType>(sql));
    }

    [HttpGet("queries")]
    public async Task<IActionResult> Queries([FromQuery] int typeId)
    {
        var personId = CurrentPersonId();
        const string sql = """
            SELECT CODIGOCONSULTASQL AS Id, LTRIM(RTRIM(NOMBRECONSULTA)) AS Name, CONSULTA AS SqlText
            FROM dbo.ListarConsultasXUsuario(@PersonId, @TypeId)
            ORDER BY NOMBRECONSULTA;
            """;
        await using var connection = connectionFactory.Create();
        var rows = await connection.QueryAsync<StoredQuery>(sql, new { PersonId = personId, TypeId = typeId });
        return Ok(rows.Select(row => new ReportQuery(
            row.Id, row.Name, ParameterRegex().Matches(row.SqlText)
                .Select(match => match.Value[1..].ToUpperInvariant())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Select(ParameterDefinition)
                .ToArray())));
    }

    [HttpPost("{queryId:int}/execute")]
    public async Task<IActionResult> Execute(int queryId, [FromBody] ExecuteReportRequest request)
    {
        var personId = CurrentPersonId();
        const string findSql = """
            SELECT TOP (1) CE.CONSULTA AS SqlText
            FROM dbo.CONSULTASESPECIALES CE
            WHERE CE.CODIGOCONSULTASQL = @QueryId AND CE.ESTADOCONSULTA = 'A'
              AND EXISTS (
                SELECT 1 FROM dbo.ListarConsultasXUsuario(@PersonId, CE.CODIGOTIPOCONSULTA) U
                WHERE U.CODIGOCONSULTASQL = CE.CODIGOCONSULTASQL
              );
            """;
        await using var connection = connectionFactory.Create();
        var sqlText = await connection.QuerySingleOrDefaultAsync<string>(findSql, new { QueryId = queryId, PersonId = personId });
        if (string.IsNullOrWhiteSpace(sqlText)) return NotFound();

        var parameterNames = ParameterRegex().Matches(sqlText)
            .Select(match => match.Value[1..].ToUpperInvariant())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
        var parameters = new DynamicParameters();
        foreach (var name in parameterNames)
        {
            request.Parameters.TryGetValue(name, out var value);
            request.Parameters.TryGetValue($"@{name}", out var valueWithPrefix);
            value ??= valueWithPrefix;
            if (string.IsNullOrWhiteSpace(value))
                return BadRequest(new { error = $"Falta el parámetro {name}." });
            parameters.Add(name, ConvertParameter(name, value));
        }

        var command = new CommandDefinition($"SET ROWCOUNT 500; {sqlText}; SET ROWCOUNT 0;", parameters, commandTimeout: 120);
        var rows = (await connection.QueryAsync(command))
            .Select(row => (IDictionary<string, object?>)row)
            .Select(row => row.ToDictionary(item => item.Key, item => NormalizeValue(item.Value)))
            .ToArray();
        var columns = rows.FirstOrDefault()?.Keys.ToArray() ?? [];
        return Ok(new { columns, rows, limited = rows.Length >= 500 });
    }

    private int CurrentPersonId() =>
        int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub"), out var value)
            ? value : throw new UnauthorizedAccessException();

    private static object ConvertParameter(string name, string value)
    {
        if (name.Contains("FECHA", StringComparison.OrdinalIgnoreCase) && DateTime.TryParse(value, out var date)) return date;
        if ((name.StartsWith("ID", StringComparison.OrdinalIgnoreCase) || name.Contains("CODIGO", StringComparison.OrdinalIgnoreCase))
            && int.TryParse(value, out var number)) return number;
        return value.Trim();
    }

    private static object? NormalizeValue(object? value) =>
        value is DateTime date ? date.ToString("yyyy-MM-ddTHH:mm:ss") :
        value is byte[] ? "[Dato binario]" : value;

    private static ReportParameter ParameterDefinition(string name)
    {
        var normalized = name.ToUpperInvariant();
        var type = normalized.Contains("FECHA") ? "date" : normalized.StartsWith("ID") ? "number" : "text";
        var label = normalized switch
        {
            "FECHAI" => "Fecha inicial",
            "FECHAF" => "Fecha final",
            "IDCENTROCOSTO" => "Centro de costo",
            "IDPROVEEDOR" => "NIT proveedor",
            "NROORDENSAP" => "Número orden SAP",
            "OMSERVICIO" => "OM - Servicio",
            _ => normalized
        };
        return new ReportParameter(normalized, label, type);
    }

    [GeneratedRegex(@"(?<!@)@[A-Za-z_][A-Za-z0-9_]*", RegexOptions.IgnoreCase)]
    private static partial Regex ParameterRegex();

    private sealed record StoredQuery(int Id, string Name, string SqlText);
    public sealed record ReportType(int Id, string Name);
    public sealed record ReportQuery(int Id, string Name, IReadOnlyList<ReportParameter> Parameters);
    public sealed record ReportParameter(string Name, string Label, string Type);
    public sealed record ExecuteReportRequest(Dictionary<string, string?> Parameters);
}
