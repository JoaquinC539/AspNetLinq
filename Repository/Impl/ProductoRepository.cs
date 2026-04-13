using AspNetLinq.Contexts;
using AspNetLinq.Models.Producto;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

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

    private IQueryable<ProductoDto> GetBaseQuery(int limit, int offset, int? marcaId,bool count)
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

        if (!count)
        {
            query = query.Skip((int)offset * (int)limit);
            query=query.Take((int)limit );
        }
        
        return  query;
    }
    public List<ProductoDto> GetAllQueriable(int limit, int offset, int? marcaId)
    {
        var query = GetBaseQuery(limit, offset, marcaId,false);
        return query.ToList();
    }

    public List<ProductoDto> GetAllNativeQuery(int limit, int offset, int? marcaId)
    {
        return _context.Database.SqlQuery<ProductoDto>($@"
            SELECT pd.*,m.Nombre MarcaNombre FROM Productos pd
            JOIN Marcas m ON pd.MarcaId = m.Id
            WHERE m.Id = {marcaId} OR  {marcaId} IS NULL
            LIMIT {limit} OFFSET {offset}
        ")
            .ToList();
    }

    public int CountQueryable(int limit, int offset, int? marcaId)
    {
        var query = GetBaseQuery(limit, offset, marcaId,true);
        return query.Count();
    }
}