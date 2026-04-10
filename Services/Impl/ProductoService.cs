using AspNetLinq.Contexts;
using AspNetLinq.Excpetions;
using AspNetLinq.Models.Producto;
using AspNetLinq.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetLinq.Services.Impl;

public class ProductoService : IProductoService
{
    private readonly ILogger<ProductoService> _logger;
    private readonly DataContext _context;
    private IProductoRepository _productoRepository;

    public ProductoService(ILogger<ProductoService> logger, DataContext context,  IProductoRepository productoRepository)
    {
        _logger = logger;
        _context = context;
        _productoRepository = productoRepository;
    }

    public Producto Post(Producto producto)
    {
        var _=_context.Marcas.Where(m=>m.Id==producto.MarcaId).Select(m=>(int?)m.Id).SingleOrDefault() ?? throw new CompanyException("Marca no encontrado");
        producto.CodigoProducto = Utils.Utils.Generate20LenghtCode();
        _context.Productos.Add(producto);
        _context.SaveChanges();
        return producto;
    }

    public List<ProductoDto> GetAll(int? limit, int? offset, int? marcaId)
    {
        limit ??= 10;
        offset ??= 0;
       return _productoRepository.GetAllQueriable((int)limit, (int)offset, marcaId);

    }
    
    public List<ProductoDto> GetAllNative(int? limit, int? offset, int? marcaId)
    {
        limit ??= 10;
        offset ??= 0;
        return _productoRepository.GetAllNativeQuery((int)limit, (int)offset, marcaId);

    }
    
    public int GetCount()
    {
        return _context.Productos.Count();
    }
}