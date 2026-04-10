using AspNetLinq.Models.Producto;

namespace AspNetLinq.Repository;

public interface IProductoRepository
{
    public List<ProductoDto> GetAllQueriable(int limit, int offset, int? marcaId);

}