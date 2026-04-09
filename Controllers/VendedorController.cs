using AspNetLinq.Models.Vendedor;
using AspNetLinq.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace AspNetLinq.Controllers;

[ApiController]
[Route("vendedor")]
public class VendedorController : ControllerBase
{
    private readonly ILogger<VendedorController> _logger;
    
    private readonly IVendedorService _vendedorService;
    public VendedorController(ILogger <VendedorController> logger, IVendedorService vendedorService)
    {
        _logger = logger;
        _vendedorService = vendedorService;
    }
    
    [HttpPost]
    public ActionResult<IEnumerable<Vendedor>> Post([FromBody] Vendedor vendedor)
    {
        _logger.LogInformation("At Vendedor Post Controller");
        return Ok(_vendedorService.Post(vendedor));
    }
    
}