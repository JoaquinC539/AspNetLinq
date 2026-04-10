using AspNetLinq.Contexts;
using AspNetLinq.Excpetions;
using AspNetLinq.Models.Producto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetLinq.Services.Impl;

public class ProductoService : IProductoService
{
    private readonly ILogger<ProductoService> _logger;
    private readonly DataContext _context;

    public ProductoService(ILogger<ProductoService> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
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
        var query = (from producto in _context.Productos
                join marca in _context.Marcas on producto.MarcaId equals marca.Id
                select new ProductoDto
                {
                    Id = producto.Id,
                    CodigoProducto = producto.CodigoProducto,
                    MarcaId = marca.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Descripcion = producto.Descripcion,
                    MarcaNombre = marca.Nombre
                }
                
            );
        if (marcaId != null)
        {
            query = query.Where(m => m.MarcaId == marcaId);
        }

        query = query.Skip((int)offset * (int)limit);
        query=query.Take((int)limit );
        return query.ToList();

    }
    
    public int GetCount()
    {
        return _context.Productos.Count();
    }
}