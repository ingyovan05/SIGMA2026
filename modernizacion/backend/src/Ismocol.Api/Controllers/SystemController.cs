using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ismocol.Api.Controllers;

[ApiController]
[Route("api/system")]
public sealed class SystemController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("health")]
    public IActionResult Health() => Ok(new { status = "ok", version = "1.0.0" });

    [Authorize]
    [HttpGet("modules")]
    public IActionResult Modules() => Ok(new[]
    {
        new { key = "principal", name = "Inicio", status = "available" },
        new { key = "bodega", name = "Bodega y almacén", status = "planned" },
        new { key = "compras", name = "Compras", status = "planned" },
        new { key = "requisiciones", name = "Requisiciones", status = "planned" },
        new { key = "contratos", name = "Contratos", status = "planned" },
        new { key = "siscontrol", name = "SisControl", status = "planned" },
        new { key = "hse", name = "HSE", status = "planned" }
    });
}
