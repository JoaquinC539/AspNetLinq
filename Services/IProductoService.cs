using AspNetLinq.Models.Producto;

namespace AspNetLinq.Services;

public interface IProductoService
{
    public Producto Post(Producto producto);
    
    public List<ProductoDto> GetAll(int? limit,int? offset,int? marcaId);
    
    public List<ProductoDto> GetAllNative(int? limit,int? offset,int? marcaId);
    
    public int GetCount();
}