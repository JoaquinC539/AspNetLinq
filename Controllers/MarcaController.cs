using AspNetLinq.Models.Marca;
using AspNetLinq.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLinq.Controllers;
[ApiController]
[Route("[controller]")]
public class MarcaController : ControllerBase
{
    private readonly ILogger<MarcaController> _logger;
    private readonly IMarcaService _marcaService;
    public MarcaController(ILogger<MarcaController> logger, IMarcaService marcaService)
    {
        _logger = logger;
        _marcaService = marcaService;
    }

    [HttpPost]
    public ActionResult<Marca> Post([FromBody] Marca marca)
    {
        return Ok(_marcaService.Post(marca));
    }

    [HttpGet]
    public ActionResult<List<Marca>> GetAll([FromQuery] int? limit, [FromQuery] int? offset)
    {
        return Ok(_marcaService.GetAll(offset , limit ));
    }

    [HttpGet]
    [Route("count")]
    public ActionResult<int> GetCount()
    {
        return Ok(_marcaService.GetCount());
    }
    
}