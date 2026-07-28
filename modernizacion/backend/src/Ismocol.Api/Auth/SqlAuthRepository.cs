using System.Data;
using Dapper;
using Ismocol.Api.Infrastructure;

namespace Ismocol.Api.Auth;

public sealed class SqlAuthRepository(ISqlConnectionFactory connectionFactory) : IAuthRepository
{
    public async Task<UserSession?> AuthenticateAsync(
        string encryptedUserName,
        string encryptedPassword,
        CancellationToken cancellationToken)
    {
        await using var connection = connectionFactory.Create();
        var parameters = new DynamicParameters();
        parameters.Add("@NOMBREUSUARIO", encryptedUserName, DbType.String);
        parameters.Add("@CONTRASEÑA", encryptedPassword, DbType.String);

        var user = await connection.QuerySingleOrDefaultAsync<LegacyUserRow>(
            new CommandDefinition(
                "dbo._ProcCargarDatosUsuarioIngreso",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken));

        if (user is null)
        {
            return null;
        }

        const string permissionsSql = """
            SELECT
                UF.CODIGOFUNCIONMODULO AS FunctionCode,
                CAST(COALESCE(UP.TIENEPERMISO, 0) AS bit) AS Granted
            FROM dbo.USU_FUNCION AS UF
            LEFT JOIN dbo.USU_PERMISO AS UP
                ON UP.CODIGOFUNCIONMODULO = UF.CODIGOFUNCIONMODULO
               AND UP.IDPERSONA = @PersonId;
            """;

        var permissions = (await connection.QueryAsync<UserPermission>(
            new CommandDefinition(
                permissionsSql,
                new { PersonId = user.IDPERSONA },
                cancellationToken: cancellationToken))).AsList();

        var warehouse = user.IDBODEGA is null
            ? null
            : new WarehouseContext(
                user.IDBODEGA.Value, user.ABREVIATURA?.Trim(), user.NOMBRE?.Trim(),
                user.DIRECCION?.Trim(), user.IDCENTROCOSTOBODEGA, user.TIPOBODEGA?.Trim(), user.IDEMPRESA);

        var sisControl = user.IDDEPENDENCIA is null
            ? null
            : new SisControlContext(
                user.IDDEPENDENCIA.Value, user.IDBASESISCONTROL, user.IDCENTROCOSTOSISCONTROL,
                user.ABREVIATURABASE?.Trim(), user.NOMBREBASE?.Trim(),
                user.NOMBREDEPENDENCIA?.Trim(), user.IDEMPRESA_SC);

        return new UserSession(
            user.IDPERSONA,
            user.NOMBRECOMPLETO?.Trim() ?? string.Empty,
            user.IDENTIFICACION?.Trim() ?? string.Empty,
            user.CODIGOTIPOUSUARIO,
            warehouse,
            sisControl,
            permissions);
    }
}
