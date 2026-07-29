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
            SELECT TOP (100) LTRIM(RTRIM(CODIGOPOBLACION)) AS Code,
                LTRIM(RTRIM(NOMBREPOBLACION)) AS Name
            FROM dbo.MA_POBLACION
            WHERE (@Search = '' OR NOMBREPOBLACION LIKE '%' + @Search + '%')
            ORDER BY NOMBREPOBLACION;
            """;
        await using var connection = connectionFactory.Create();
        return Ok(await connection.QueryAsync<LookupItem>(sql, new { Search = search?.Trim() ?? string.Empty }));
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
