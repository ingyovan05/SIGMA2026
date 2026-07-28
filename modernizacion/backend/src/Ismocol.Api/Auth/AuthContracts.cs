namespace Ismocol.Api.Auth;

public sealed record LoginRequest(string UserName, string Password);

public sealed record LoginResponse(string AccessToken, DateTimeOffset ExpiresAt, UserSession User);

public sealed record UserSession(
    int PersonId,
    string FullName,
    string Identification,
    int UserTypeCode,
    WarehouseContext? Warehouse,
    SisControlContext? SisControl,
    IReadOnlyList<UserPermission> Permissions);

public sealed record WarehouseContext(
    int Id,
    string? Abbreviation,
    string? Name,
    string? Address,
    int? CostCenterId,
    string? Type,
    int? CompanyId);

public sealed record SisControlContext(
    int DependencyId,
    int? BaseId,
    int? CostCenterId,
    string? BaseAbbreviation,
    string? BaseName,
    string? DependencyName,
    int? CompanyId);

public sealed record UserPermission(int FunctionCode, bool Granted);

internal sealed class LegacyUserRow
{
    public int IDPERSONA { get; init; }
    public string? NOMBRECOMPLETO { get; init; }
    public string? IDENTIFICACION { get; init; }
    public int CODIGOTIPOUSUARIO { get; init; }
    public int? IDBODEGA { get; init; }
    public string? ABREVIATURA { get; init; }
    public string? NOMBRE { get; init; }
    public string? DIRECCION { get; init; }
    public int? IDCENTROCOSTOBODEGA { get; init; }
    public string? TIPOBODEGA { get; init; }
    public int? IDEMPRESA { get; init; }
    public int? IDDEPENDENCIA { get; init; }
    public int? IDBASESISCONTROL { get; init; }
    public int? IDCENTROCOSTOSISCONTROL { get; init; }
    public string? ABREVIATURABASE { get; init; }
    public string? NOMBREBASE { get; init; }
    public string? NOMBREDEPENDENCIA { get; init; }
    public int? IDEMPRESA_SC { get; init; }
}
