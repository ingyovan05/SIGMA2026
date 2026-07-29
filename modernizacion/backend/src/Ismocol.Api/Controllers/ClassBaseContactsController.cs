using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Claims;
using Dapper;
using Ismocol.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

/// <summary>
/// API reutilizable que reemplaza el control heredado ClasesBase.Cu_Contacto.
/// </summary>
[Authorize]
[ApiController]
[Route("api/class-base/contacts")]
public sealed class ClassBaseContactsController(ISqlConnectionFactory connectionFactory) : ControllerBase
{
    [HttpGet("{personId:int}")]
    public async Task<IActionResult> Get(int personId)
    {
        const string sql = """
            SELECT P.IDPERSONA AS PersonId,
                LTRIM(RTRIM(CONCAT(P.PRIMERNOMBRE, ' ', P.SEGUNDONOMBRE, ' ', P.PRIMERAPELLIDO, ' ', P.SEGUNDOAPELLIDO))) AS FullName,
                ISNULL(LTRIM(RTRIM(P.CORREOELECTRONICO)), '') AS PersonalEmail,
                ISNULL(LTRIM(RTRIM(P.TELEFONOMOVIL)), '') AS PersonalMobile,
                ISNULL(LTRIM(RTRIM(U.CORREOELECTRONICOCORPORTATIVO)), '') AS CorporateEmail,
                ISNULL(LTRIM(RTRIM(U.TELEFONOMOVILCORPORATIVO)), '') AS CorporateMobile
            FROM dbo.PERSONA P
            LEFT JOIN dbo.USUARIO U ON U.IDPERSONA = P.IDPERSONA
            WHERE P.IDPERSONA = @PersonId;
            """;
        await using var connection = connectionFactory.Create();
        var contact = await connection.QuerySingleOrDefaultAsync<Contact>(sql, new { PersonId = personId });
        return contact is null ? NotFound() : Ok(contact);
    }

    [HttpPut("{personId:int}")]
    public async Task<IActionResult> Update(int personId, [FromBody] UpdateContact request)
    {
        if (!string.IsNullOrWhiteSpace(request.CorporateEmail)
            && !request.CorporateEmail.EndsWith("@ismocol.com", StringComparison.OrdinalIgnoreCase))
            return BadRequest(new { error = "El correo corporativo debe pertenecer al dominio ismocol.com." });

        var modifierClaim = User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? User.FindFirstValue("sub");
        if (!int.TryParse(modifierClaim, out var modifierId)) return Unauthorized();

        var parameters = new DynamicParameters();
        parameters.Add("@IDPERSONA", personId);
        parameters.Add("@CORREOELECTRONICO", request.PersonalEmail?.Trim());
        parameters.Add("@TELEFONOMOVIL", request.PersonalMobile?.Trim());
        parameters.Add("@CORREOELECTRONICOCORPORTATIVO", request.CorporateEmail?.Trim());
        parameters.Add("@TELEFONOMOVILCORPORATIVO", request.CorporateMobile?.Trim());
        parameters.Add("@IDPERSONAMODIFICA", modifierId);

        await using var connection = connectionFactory.Create();
        await connection.ExecuteAsync("dbo.ActualizarContacto", parameters, commandType: CommandType.StoredProcedure);
        return NoContent();
    }

    public sealed record Contact(
        int PersonId, string FullName, string PersonalEmail, string PersonalMobile,
        string CorporateEmail, string CorporateMobile);

    public sealed record UpdateContact(
        [EmailAddress] string? PersonalEmail,
        string? PersonalMobile,
        [EmailAddress] string? CorporateEmail,
        string? CorporateMobile);
}
