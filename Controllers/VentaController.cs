using AspNetLinq.Models.Venta;
using AspNetLinq.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLinq.Controllers;

[ApiController]
[Route("[controller]")]
public class VentaController :ControllerBase
{
    private readonly ILogger<VentaController> _logger;
    private readonly IVentaService _ventaService;

    public VentaController(ILogger<VentaController> logger, IVentaService ventaService)
    {
        _logger = logger;
        _ventaService = ventaService;
    }

    [HttpPost]
    public ActionResult<Venta> Post([FromBody] Venta venta)
    {
        return Ok(_ventaService.Post(venta));
    }
    
    
}