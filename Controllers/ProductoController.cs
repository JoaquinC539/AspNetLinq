using AspNetLinq.Models.Producto;
using AspNetLinq.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLinq.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ILogger<ProductoController> _logger;
    private readonly IProductoService _productoService;

    public ProductoController(ILogger<ProductoController> logger, IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    [HttpPost]
    public ActionResult<Producto> Post([FromBody] Producto producto)
    {
        return Ok(_productoService.Post(producto));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Producto>> GetAll([FromQuery] int? offset, [FromQuery] int? limit,
        [FromQuery] int? marcaId)
    {
        return Ok(_productoService.GetAll(limit, offset, marcaId));
    }
    
    [HttpGet]
    [Route("native")]
    public ActionResult<IEnumerable<Producto>> GetAllNative([FromQuery] int? offset, [FromQuery] int? limit,
        [FromQuery] int? marcaId)
    {
        return Ok(_productoService.GetAllNative(limit, offset, marcaId));
    }
    
    [HttpGet]
    [Route("count")]
    public ActionResult<int> Count([FromQuery] int? offset, [FromQuery] int? limit,
        [FromQuery] int? marcaId)
    {
        return Ok(_productoService.GetCount(limit, offset, marcaId));
    }
    
}