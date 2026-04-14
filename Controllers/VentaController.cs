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

    [HttpGet]
    public ActionResult<VentaDTO> Get([FromQuery] int? offset, [FromQuery] int? limit,
        [FromQuery] int? vendedorId, [FromQuery] int? productoId)
    {
        return Ok(_ventaService.GetAll(limit, offset, vendedorId, productoId));
    }

    [HttpGet]
    [Route("count")]
    public ActionResult<int> Count([FromQuery] int? offset, [FromQuery] int? limit,
        [FromQuery] int? vendedorId, [FromQuery] int? productoId)
    {
        return Ok(_ventaService.GetCount(limit, offset, vendedorId, productoId));
    }
    
    
}