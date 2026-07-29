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
        [FromQuery] int take = 50,
        CancellationToken cancellationToken = default)
    {
        var personId = CurrentPersonId();
        if (personId is null) return Unauthorized();

        var definition = category.ToLowerInvariant() switch
        {
            "medical-exams" => new LegacyList(
                "dbo.ListarEnvioExamenes",
                new { WHERE = "", IdPersona = personId.Value, IdBase = baseId, AccionEspecial = 1, TOP = Math.Clamp(take, 1, 200) }),
            "covid-surveys" => new LegacyList(
                "dbo.ListarEncuestas",
                new { WHERE = "", IdPersona = personId.Value, IdBase = baseId, AccionEspecial = 1, TOP = Math.Clamp(take, 1, 200) }),
            "qualifications" => new LegacyList(
                "dbo.ListaCalificaciones",
                new { WHERE = "", AccionEspecial = 1, TOP = Math.Clamp(take, 1, 200) }),
            "performance-evaluations" => new LegacyList(
                "dbo.ListarEvaluacionDesempeño",
                new { WHERE = "", AccionEspecial = 0, TOP = Math.Clamp(take, 1, 200) }),
            _ => null
        };
        if (definition is null) return NotFound(new { error = "Categoría de Personal no reconocida." });

        await using var connection = connectionFactory.Create();
        var command = new CommandDefinition(
            definition.Procedure, definition.Parameters, commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);
        var rows = await connection.QueryAsync(command);
        return Ok(rows.Select(row => (IDictionary<string, object?>)row));
    }

    private int? CurrentPersonId()
    {
        var value = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");
        return int.TryParse(value, out var personId) ? personId : null;
    }

    private sealed record LegacyList(string Procedure, object Parameters);
}
