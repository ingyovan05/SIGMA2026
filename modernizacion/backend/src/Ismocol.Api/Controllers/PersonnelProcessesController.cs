using System.Data;
using System.Security.Claims;
using Dapper;
using Ismocol.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/personnel/processes")]
public sealed class PersonnelProcessesController(ISqlConnectionFactory connectionFactory) : ControllerBase
{
    [HttpGet("{category}")]
    public async Task<IActionResult> List(
        string category,
        [FromQuery] int baseId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var personId = CurrentPersonId();
        if (personId is null) return Unauthorized();

        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);
        var requestedTop = checked(page * pageSize);
        var definition = category.ToLowerInvariant() switch
        {
            "medical-exams" => new LegacyList(
                "dbo.ListarEnvioExamenes",
                new { WHERE = "", IdPersona = personId.Value, IdBase = baseId, AccionEspecial = 1, TOP = requestedTop }),
            "covid-surveys" => new LegacyList(
                "dbo.ListarEncuestas",
                new { WHERE = "", IdPersona = personId.Value, IdBase = baseId, AccionEspecial = 1, TOP = requestedTop }),
            "qualifications" => new LegacyList(
                "dbo.ListaCalificaciones",
                new { WHERE = "", AccionEspecial = 1, TOP = requestedTop }),
            "performance-evaluations" => new LegacyList(
                "dbo.ListarEvaluacionDesempeño",
                new { WHERE = "", AccionEspecial = 0, TOP = requestedTop }),
            _ => null
        };
        if (definition is null) return NotFound(new { error = "Categoría de Personal no reconocida." });

        await using var connection = connectionFactory.Create();
        var command = new CommandDefinition(
            definition.Procedure, definition.Parameters, commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);
        using var grid = await connection.QueryMultipleAsync(command);
        var firstResult = (await grid.ReadAsync()).AsList();
        var total = ExtractTotal(firstResult);
        var rows = grid.IsConsumed ? firstResult : (await grid.ReadAsync()).AsList();
        var items = rows.Skip((page - 1) * pageSize).Take(pageSize)
            .Select(row => (IDictionary<string, object?>)row).ToList();
        if (total == 0) total = rows.Count;
        return Ok(new { items, total, page, pageSize });
    }

    private int? CurrentPersonId()
    {
        var value = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");
        return int.TryParse(value, out var personId) ? personId : null;
    }

    private static long ExtractTotal(IReadOnlyList<dynamic> rows)
    {
        if (rows.Count == 0) return 0;
        var values = (IDictionary<string, object?>)rows[0];
        var count = values.FirstOrDefault(item =>
            item.Key.Equals("CONTEO", StringComparison.OrdinalIgnoreCase)
            || item.Key.Equals("COUNT", StringComparison.OrdinalIgnoreCase)).Value;
        return count is null ? 0 : Convert.ToInt64(count);
    }

    private sealed record LegacyList(string Procedure, object Parameters);
}
