using AspNetLinq.Models.Producto;

namespace AspNetLinq.Repository;

public interface IProductoRepository
{
    public List<ProductoDto> GetAllQueriable(int limit, int offset, int? marcaId);

    public List<ProductoDto> GetAllNativeQuery(int limit, int offset, int? marcaId);
    
    public int CountQueryable(int limit, int offset, int? marcaId);
}