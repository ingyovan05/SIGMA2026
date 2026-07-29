using System.Data;
using System.Security.Claims;
using Dapper;
using Ismocol.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/personnel")]
public sealed class PersonnelTransactionsController(ISqlConnectionFactory connectionFactory) : ControllerBase
{
    [HttpPost("surveys")]
    public Task<IActionResult> CreateSurvey([FromBody] SurveyRequest request) =>
        SaveSurvey(1, null, request, 775);

    [HttpPut("surveys/{surveyId:long}")]
    public Task<IActionResult> UpdateSurvey(long surveyId, [FromBody] SurveyRequest request) =>
        SaveSurvey(2, surveyId, request, 776);

    [HttpPost("performance-evaluations")]
    public Task<IActionResult> CreateEvaluation([FromBody] EvaluationRequest request) =>
        SaveEvaluation(1, null, request, 860);

    [HttpPut("performance-evaluations/{evaluationId:int}")]
    public Task<IActionResult> UpdateEvaluation(int evaluationId, [FromBody] EvaluationRequest request) =>
        SaveEvaluation(6, evaluationId, request, 862);

    private async Task<IActionResult> SaveSurvey(byte action, long? surveyId, SurveyRequest request, int permission)
    {
        if (!HasPermission(permission)) return Forbid();
        if (request.PersonId <= 0 || request.BaseId < 0 || request.Answers is not { Length: 10 })
            return BadRequest(new { error = "Persona, base y las diez respuestas son obligatorias." });
        if (request.Answers.Any(answer => answer is not ("S" or "N")))
            return BadRequest(new { error = "Cada respuesta debe ser S o N." });

        var actorId = CurrentPersonId();
        if (actorId is null) return Unauthorized();
        var parameters = new DynamicParameters();
        parameters.Add("@ACCION", action, DbType.Byte);
        parameters.Add("@IDPERSONA", request.PersonId);
        parameters.Add("@IDBASESISCONTROL", request.BaseId);
        parameters.Add("@PROYECTO", request.Project.Trim());
        parameters.Add("@FECHAENCUESTA", request.SurveyDate.Date);
        parameters.Add("@EDAD", request.Age, DbType.Byte);
        parameters.Add("@NOMBRETIPOCARGO", request.Position.Trim());
        for (var index = 0; index < 10; index++) parameters.Add($"@RESPUESTA{index + 1}", request.Answers[index]);
        parameters.Add("@IDPERSONARESPONDE", actorId.Value);
        parameters.Add("@FECHARESPONDE", DateTime.Now);
        parameters.Add("@CLAVEACCESOWEB", null);
        parameters.Add("@LLENOVIAWEB", "N");
        parameters.Add("@CORREOELECTRONICO", request.Email?.Trim());
        parameters.Add("@AUTORIZADOMEDICO", null);
        parameters.Add("@IDUSUARIO", actorId.Value);
        parameters.Add("@ID_DM_ENCUESTA", surveyId);
        parameters.Add("@MENSAJE", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@CONSECUTIVO", dbType: DbType.String, size: 8, direction: ParameterDirection.Output);

        await using var connection = connectionFactory.Create();
        await connection.ExecuteAsync("dbo.GestionarEncuesta", parameters, commandType: CommandType.StoredProcedure);
        return Ok(new { message = parameters.Get<int?>("@MENSAJE"), consecutive = parameters.Get<string?>("@CONSECUTIVO")?.Trim() });
    }

    private async Task<IActionResult> SaveEvaluation(byte action, int? evaluationId, EvaluationRequest request, int permission)
    {
        if (!HasPermission(permission)) return Forbid();
        if (request.EvaluatedPersonId <= 0 || request.EvaluatorPersonId <= 0
            || request.EvaluatedPersonId == request.EvaluatorPersonId)
            return BadRequest(new { error = "Seleccione personas diferentes para evaluado y evaluador." });

        var actorId = CurrentPersonId();
        if (actorId is null) return Unauthorized();
        var parameters = new DynamicParameters();
        parameters.Add("@ACCION", action);
        parameters.Add("@IDEVALUACIONDESEMPEÑO", evaluationId);
        parameters.Add("@IDPERSONAEVALUADO", request.EvaluatedPersonId);
        parameters.Add("@IDPERSONAEVALUA", request.EvaluatorPersonId);
        parameters.Add("@PERIODO", request.Period.Trim());
        parameters.Add("@CARGOEVALUADO", request.EvaluatedPosition.Trim());
        parameters.Add("@CARGOEVALUA", request.EvaluatorPosition.Trim());
        parameters.Add("@CORREOELECTRONICOEVALUA", request.EvaluatorEmail.Trim());
        parameters.Add("@PROYECTO", request.Project.Trim());
        parameters.Add("@CLAVEACCESOWEB", null);
        foreach (var prefix in new[] { "COM", "EXP", "OPT", "ORI", "PLA", "GES", "CAP", "OBS", "DIN", "TRA" })
            for (var index = 1; index <= 3; index++) parameters.Add($"@{prefix}{index}", null);
        for (var index = 1; index <= 20; index++) parameters.Add($"@SEG{index}", null);
        for (var index = 1; index <= 4; index++) parameters.Add($"@SST{index}", null);
        parameters.Add("@ASPECTOMEJORAR", null);
        parameters.Add("@NIVELDESEMPEÑOTOTAL", null);
        parameters.Add("@IDUSUARIOREGISTRO", actorId.Value);
        parameters.Add("@IDUSUARIOMODIFICA", actorId.Value);
        parameters.Add("@ESTADO", request.Status);
        parameters.Add("@MENSAJE", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@CONSECUTIVO", dbType: DbType.String, size: 8, direction: ParameterDirection.Output);

        await using var connection = connectionFactory.Create();
        await connection.ExecuteAsync("dbo.GestionarEvaluaciónDesempeño", parameters, commandType: CommandType.StoredProcedure);
        return Ok(new { message = parameters.Get<int?>("@MENSAJE"), consecutive = parameters.Get<string?>("@CONSECUTIVO")?.Trim() });
    }

    private int? CurrentPersonId()
    {
        var value = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");
        return int.TryParse(value, out var id) ? id : null;
    }

    private bool HasPermission(int permission) => User.HasClaim("permission", permission.ToString());

    public sealed record SurveyRequest(
        int PersonId, int BaseId, string Project, DateTime SurveyDate, byte Age,
        string Position, string? Email, string[] Answers);

    public sealed record EvaluationRequest(
        int EvaluatedPersonId, int EvaluatorPersonId, string Period, string EvaluatedPosition,
        string EvaluatorPosition, string EvaluatorEmail, string Project, string Status);
}
