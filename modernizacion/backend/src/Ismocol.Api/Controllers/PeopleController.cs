using Dapper;
using Ismocol.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/people")]
public sealed class PeopleController(ISqlConnectionFactory connectionFactory) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] string? search, [FromQuery] int take = 50)
    {
        const string sql = """
            SELECT TOP (@Take)
                P.IDPERSONA AS Id,
                LTRIM(RTRIM(P.IDENTIFICACION)) AS Identification,
                LTRIM(RTRIM(CONCAT(P.PRIMERNOMBRE, ' ', P.SEGUNDONOMBRE, ' ', P.PRIMERAPELLIDO, ' ', P.SEGUNDOAPELLIDO))) AS FullName,
                LTRIM(RTRIM(P.TELEFONOMOVIL)) AS Mobile,
                LTRIM(RTRIM(P.CORREOELECTRONICO)) AS Email,
                P.FECHANACIMIENTO AS BirthDate
            FROM dbo.PERSONA P
            WHERE (@Search = ''
                OR P.IDENTIFICACION LIKE '%' + @Search + '%'
                OR CONCAT(P.PRIMERNOMBRE, ' ', P.SEGUNDONOMBRE, ' ', P.PRIMERAPELLIDO, ' ', P.SEGUNDOAPELLIDO) LIKE '%' + @Search + '%')
            ORDER BY P.PRIMERAPELLIDO, P.SEGUNDOAPELLIDO, P.PRIMERNOMBRE;
            """;

        await using var connection = connectionFactory.Create();
        var rows = await connection.QueryAsync<PersonSummary>(sql, new
        {
            Search = search?.Trim() ?? string.Empty,
            Take = Math.Clamp(take, 1, 200)
        });
        return Ok(rows);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        const string sql = """
            SELECT
                P.IDPERSONA AS Id,
                LTRIM(RTRIM(P.IDENTIFICACION)) AS Identification,
                LTRIM(RTRIM(P.PRIMERNOMBRE)) AS FirstName,
                LTRIM(RTRIM(P.SEGUNDONOMBRE)) AS MiddleName,
                LTRIM(RTRIM(P.PRIMERAPELLIDO)) AS LastName,
                LTRIM(RTRIM(P.SEGUNDOAPELLIDO)) AS SecondLastName,
                P.FECHANACIMIENTO AS BirthDate,
                LTRIM(RTRIM(P.GENERO)) AS Gender,
                LTRIM(RTRIM(P.DIRECCION)) AS Address,
                LTRIM(RTRIM(P.TELEFONO)) AS Phone,
                LTRIM(RTRIM(P.TELEFONOMOVIL)) AS Mobile,
                LTRIM(RTRIM(P.CORREOELECTRONICO)) AS Email,
                LTRIM(RTRIM(P.CODIGOLUGARNACIMIENTO)) AS BirthCityCode,
                LTRIM(RTRIM(P.CODIGOLUGARDIRECCION)) AS ResidenceCityCode,
                (SELECT TOP 1 LTRIM(RTRIM(C.NOMBREPOBLACION)) FROM dbo.MA_POBLACION C WHERE C.CODIGOPOBLACION = P.CODIGOLUGARNACIMIENTO) AS BirthCity,
                (SELECT TOP 1 LTRIM(RTRIM(C.NOMBREPOBLACION)) FROM dbo.MA_POBLACION C WHERE C.CODIGOPOBLACION = P.CODIGOLUGARDIRECCION) AS ResidenceCity
            FROM dbo.PERSONA P
            WHERE P.IDPERSONA = @Id;
            """;

        await using var connection = connectionFactory.Create();
        var person = await connection.QuerySingleOrDefaultAsync<PersonDetail>(sql, new { Id = id });
        return person is null ? NotFound() : Ok(person);
    }

    public sealed record PersonSummary(int Id, string Identification, string FullName, string? Mobile, string? Email, DateTime? BirthDate);
    public sealed record PersonDetail(
        int Id, string Identification, string? FirstName, string? MiddleName, string? LastName,
        string? SecondLastName, DateTime? BirthDate, string? Gender, string? Address, string? Phone,
        string? Mobile, string? Email, string? BirthCityCode, string? ResidenceCityCode,
        string? BirthCity, string? ResidenceCity);
}
