using AspNetLinq.Contexts;
using AspNetLinq.Excpetions;
using AspNetLinq.Models.Venta;

namespace AspNetLinq.Services.Impl;

public class VentaService : IVentaService
{
    private readonly ILogger<VentaService> _logger;
    private readonly DataContext _context;

    public VentaService(DataContext context, ILogger<VentaService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public Venta Post(Venta venta)
    {
        var _1=_context.Vendedores.Where(v=>v.Id==venta.VendedorId).Select(v=>(int?) v.Id).SingleOrDefault() ?? throw new CompanyException("Vendedor no encontrado");
        var _2 = _context.Productos.Where(p=>p.Id == venta.ProductoId).Select(p=> (int?)p.Id).SingleOrDefault() ?? throw new CompanyException("Producto no encontrado");
        _context.Ventas.Add(venta);
        _context.SaveChanges();
        return venta;
    }
}