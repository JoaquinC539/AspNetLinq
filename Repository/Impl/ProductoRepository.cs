using AspNetLinq.Contexts;
using AspNetLinq.Models.Producto;

namespace AspNetLinq.Repository.Impl;

public class ProductoRepository: IProductoRepository
{
    private readonly ILogger<ProductoRepository> _logger;
    private readonly DataContext _context;

    public ProductoRepository(DataContext context, ILogger<ProductoRepository> logger)
    {
        _logger = logger;
        _context = context;
    }
    public List<ProductoDto> GetAllQueriable(int limit, int offset, int? marcaId)
    {
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
}