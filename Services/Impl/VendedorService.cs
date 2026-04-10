using AspNetLinq.Contexts;
using AspNetLinq.Controllers;
using AspNetLinq.Models.Vendedor;

namespace AspNetLinq.Services.Impl;

public class VendedorService : IVendedorService
{
    private readonly ILogger<VendedorController> _logger;
    
    private readonly DataContext _context;

    public VendedorService(ILogger<VendedorController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }
    public Vendedor Post(Vendedor vendedor)
    {
        vendedor.CodigoEmpleado = Utils.Utils.Generate20LenghtCode();
        _context.Vendedores.Add(vendedor);
        _context.SaveChanges();
        return vendedor;
    }

    public List<Vendedor> GetAll(int? limit, int? offset)
    {
        offset ??= 0;
        limit ??= 10;
        return _context.Vendedores
            .Skip((int)offset * (int)limit)
            .Take((int)limit )
            .ToList();
            
    }

    public int GetCount()
    {
        return _context.Vendedores.Count();
    }
}