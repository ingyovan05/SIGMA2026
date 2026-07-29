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
        new { key = "principal", name = "Inicio", shortName = "IN", status = "available", description = "Panel principal de SIGMA" },
        new { key = "personal", name = "Personal", shortName = "PE", status = "available", description = "Gestión de personal" },
        new { key = "contrato", name = "Contrato", shortName = "CO", status = "planned", description = "Administración contractual" },
        new { key = "ssta", name = "SSTA", shortName = "SS", status = "planned", description = "Seguridad, salud y ambiente" },
        new { key = "ordenes-trabajo", name = "Órdenes de trabajo", shortName = "OT", status = "planned", description = "Planeación y control de órdenes" },
        new { key = "reporte-diario", name = "Reporte diario", shortName = "RD", status = "planned", description = "Registro diario de operación" },
        new { key = "auditoria", name = "Auditoría", shortName = "AU", status = "planned", description = "Seguimiento y trazabilidad" },
        new { key = "siscontrol", name = "SisControl", shortName = "SC", status = "planned", description = "Control operativo" },
        new { key = "licitaciones", name = "Licitaciones", shortName = "LI", status = "planned", description = "Procesos de licitación" },
        new { key = "articulos", name = "Artículos", shortName = "AR", status = "planned", description = "Catálogo de artículos" },
        new { key = "compras", name = "Compras", shortName = "CP", status = "planned", description = "Solicitudes y órdenes de compra" },
        new { key = "bodega", name = "Bodega", shortName = "BO", status = "planned", description = "Inventario y movimientos" },
        new { key = "activos-fijos", name = "Activos fijos", shortName = "AF", status = "planned", description = "Administración de activos" },
        new { key = "sistemas-especiales", name = "Sistemas especiales", shortName = "SE", status = "planned", description = "Operaciones especializadas" },
        new { key = "actualizar", name = "Actualizar", shortName = "AC", status = "planned", description = "Actualización de componentes" },
        new { key = "informes", name = "Informes", shortName = "IF", status = "available", description = "Consulta y generación de informes" },
        new { key = "configuracion", name = "Configuración", shortName = "CF", status = "available", description = "Preferencias y contexto de trabajo" },
        new { key = "soporte", name = "Soporte", shortName = "SP", status = "available", description = "Centro de ayuda SIGMA" },
        new { key = "acceso-remoto", name = "Acceso remoto", shortName = "RM", status = "available", description = "Asistencia técnica remota" }
    });
}
