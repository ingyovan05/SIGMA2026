using System.Data;
using Dapper;
using Ismocol.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/base-configuration")]
public sealed class BaseConfigurationController(ISqlConnectionFactory connectionFactory) : ControllerBase
{
    [HttpGet("{baseId:int}")]
    public async Task<IActionResult> Get(int baseId)
    {
        await using var connection = connectionFactory.Create();
        const string sql = """
            SELECT @BaseId AS BaseId, CODIGOCONTRATOISMOCOL AS ContractCode,
                IDCENTROCOSTO AS CostCenterId, CODIGOCIUDADCONTRATACION AS CityCode,
                IDPERSONACOORDINADORQAQC AS QaqcCoordinatorId,
                IDPERSONACOORDINADORHSEC AS HseCoordinatorId, IDPERSONAMEDICO AS DoctorId,
                IDPERSONARESIDENTE AS ResidentId, IDPERSONAJEFEPERSONAL AS PeopleManagerId,
                IDPERSONAADMINISTRADOR AS AdministratorId, IDPERSONAJEFEBODEGA AS WarehouseManagerId,
                LUGARENTREGADOTACION AS WorkwearDeliveryPlace
            FROM dbo.DatosConfiguracionBase(@BaseId);
            """;
        var configuration = await connection.QuerySingleOrDefaultAsync<BaseConfiguration>(sql, new { BaseId = baseId });
        return Ok(configuration ?? new BaseConfiguration { BaseId = baseId });
    }

    [HttpGet("cities")]
    public async Task<IActionResult> Cities([FromQuery] string? search)
    {
        const string sql = """
            SELECT LTRIM(RTRIM(CODIGOPOBLACION)) AS Code,
                LTRIM(RTRIM(NOMBREPOBLACION)) AS Name
            FROM dbo.MA_POBLACION
            WHERE (@Search = '' OR CODIGOPOBLACION LIKE '%' + @Search + '%'
                OR NOMBREPOBLACION LIKE '%' + @Search + '%')
            ORDER BY NOMBREPOBLACION;
            """;
        await using var connection = connectionFactory.Create();
        return Ok(await connection.QueryAsync<LookupItem>(sql, new { Search = search?.Trim() ?? string.Empty }));
    }

    [HttpGet("cities/master")]
    public async Task<IActionResult> MasterCities([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 15)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 50);
        const string sql = """
            WITH FilteredCities AS (
                SELECT CODIGOMUNICIPIO, CODIGODEPARTAMENTO,
                    MAX(NOMBREMUNICIPIO) AS NOMBREMUNICIPIO,
                    MAX(NOMBREDEPARTAMENTO) AS NOMBREDEPARTAMENTO,
                    MAX(CODIGOPAIS) AS CODIGOPAIS,
                    MAX(NOMBREPAIS) AS NOMBREPAIS
                FROM dbo.MA_POBLACIONMAESTRA
                WHERE (@Search = '' OR CODIGOMUNICIPIO LIKE '%' + @Search + '%'
                    OR NOMBREMUNICIPIO LIKE '%' + @Search + '%'
                    OR NOMBREDEPARTAMENTO LIKE '%' + @Search + '%'
                    OR NOMBREPAIS LIKE '%' + @Search + '%')
                GROUP BY CODIGOMUNICIPIO, CODIGODEPARTAMENTO
            )
            SELECT LTRIM(RTRIM(CODIGOMUNICIPIO)) AS Code,
                LTRIM(RTRIM(NOMBREMUNICIPIO)) AS Name,
                LTRIM(RTRIM(CODIGODEPARTAMENTO)) AS DepartmentCode,
                LTRIM(RTRIM(NOMBREDEPARTAMENTO)) AS Department,
                LTRIM(RTRIM(CODIGOPAIS)) AS CountryCode,
                LTRIM(RTRIM(NOMBREPAIS)) AS Country,
                CAST(CASE WHEN EXISTS (
                    SELECT 1 FROM dbo.MA_POBLACION p
                    WHERE p.CODIGOPOBLACION = FilteredCities.CODIGOMUNICIPIO
                ) THEN 1 ELSE 0 END AS bit) AS IsUsed
            FROM FilteredCities
            ORDER BY NOMBREPAIS, NOMBREDEPARTAMENTO, NOMBREMUNICIPIO
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

            SELECT COUNT(1)
            FROM (
                SELECT CODIGOMUNICIPIO, CODIGODEPARTAMENTO
                FROM dbo.MA_POBLACIONMAESTRA
                WHERE (@Search = '' OR CODIGOMUNICIPIO LIKE '%' + @Search + '%'
                    OR NOMBREMUNICIPIO LIKE '%' + @Search + '%'
                    OR NOMBREDEPARTAMENTO LIKE '%' + @Search + '%'
                    OR NOMBREPAIS LIKE '%' + @Search + '%')
                GROUP BY CODIGOMUNICIPIO, CODIGODEPARTAMENTO
            ) GroupedCities;
            """;
        await using var connection = connectionFactory.Create();
        using var result = await connection.QueryMultipleAsync(sql, new
        {
            Search = search?.Trim() ?? string.Empty,
            Offset = (page - 1) * pageSize,
            PageSize = pageSize
        });
        var items = (await result.ReadAsync<MasterCity>()).ToArray();
        var total = await result.ReadSingleAsync<int>();
        return Ok(new { items, total, page, pageSize });
    }

    [HttpPost("cities")]
    public async Task<IActionResult> AddCity([FromBody] AddCityRequest request)
    {
        var code = request.Code?.Trim();
        if (string.IsNullOrWhiteSpace(code))
            return BadRequest(new { error = "Seleccione una ciudad del maestro." });

        const string sql = """
            DECLARE @Name nvarchar(30);
            SELECT TOP (1) @Name = LTRIM(RTRIM(NOMBREMUNICIPIO))
            FROM dbo.MA_POBLACIONMAESTRA WHERE CODIGOMUNICIPIO = @Code;
            IF @Name IS NULL
                THROW 50001, 'La ciudad no existe en MA_POBLACIONMAESTRA.', 1;
            IF NOT EXISTS (SELECT 1 FROM dbo.MA_POBLACION WHERE CODIGOPOBLACION = @Code)
                INSERT INTO dbo.MA_POBLACION
                    (CODIGOPOBLACIONNOMGEN, CODIGOPOBLACION, NOMBREPOBLACION)
                VALUES (NULL, @Code, @Name);
            SELECT @Code AS Code, @Name AS Name;
            """;
        await using var connection = connectionFactory.Create();
        return Ok(await connection.QuerySingleAsync<LookupItem>(sql, new { Code = code }));
    }

    [HttpPut("{baseId:int}")]
    public async Task<IActionResult> Save(int baseId, [FromBody] SaveBaseConfiguration request)
    {
        if (string.IsNullOrWhiteSpace(request.CityCode))
            return BadRequest(new { error = "Seleccione la ciudad de contratación." });

        await using var connection = connectionFactory.Create();
        var exists = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(1) FROM dbo.DatosConfiguracionBase(@BaseId)", new { BaseId = baseId });

        var parameters = new DynamicParameters();
        parameters.Add("@Accion", exists > 0 ? 2 : 1, DbType.Byte);
        parameters.Add("@IDBASESISCONTROL", baseId);
        parameters.Add("@CODIGOCONTRATOISMOCOL", request.ContractCode?.Trim());
        parameters.Add("@IDCENTROCOSTO", request.CostCenterId);
        parameters.Add("@CODIGOCIUDADCONTRATACION", request.CityCode.Trim());
        parameters.Add("@IDPERSONACOORDINADORQAQC", request.QaqcCoordinatorId);
        parameters.Add("@IDPERSONACOORDINADORHSEC", request.HseCoordinatorId);
        parameters.Add("@IDPERSONAMEDICO", request.DoctorId);
        parameters.Add("@IDPERSONARESIDENTE", request.ResidentId);
        parameters.Add("@IDPERSONAJEFEPERSONAL", request.PeopleManagerId);
        parameters.Add("@IDPERSONAADMINISTRADOR", request.AdministratorId);
        parameters.Add("@IDPERSONAJEFEBODEGA", request.WarehouseManagerId);
        parameters.Add("@LUGARENTREGADOTACION", request.WorkwearDeliveryPlace?.Trim());

        await connection.ExecuteAsync("dbo.GestionarConfiguracionBase", parameters, commandType: CommandType.StoredProcedure);
        return NoContent();
    }

    public sealed record LookupItem(string Code, string Name);
    public sealed record MasterCity(
        string Code, string Name, string DepartmentCode, string Department,
        string CountryCode, string Country, bool IsUsed);
    public sealed record AddCityRequest(string? Code);
    public sealed record SaveBaseConfiguration(
        string? ContractCode, int? CostCenterId, string CityCode, int? QaqcCoordinatorId,
        int? HseCoordinatorId, int? DoctorId, int? ResidentId, int? PeopleManagerId,
        int? AdministratorId, int? WarehouseManagerId, string? WorkwearDeliveryPlace);

    public sealed class BaseConfiguration
    {
        public int BaseId { get; init; }
        public string? ContractCode { get; init; }
        public int? CostCenterId { get; init; }
        public string? CityCode { get; init; }
        public int? QaqcCoordinatorId { get; init; }
        public int? HseCoordinatorId { get; init; }
        public int? DoctorId { get; init; }
        public int? ResidentId { get; init; }
        public int? PeopleManagerId { get; init; }
        public int? AdministratorId { get; init; }
        public int? WarehouseManagerId { get; init; }
        public string? WorkwearDeliveryPlace { get; init; }
    }
}
