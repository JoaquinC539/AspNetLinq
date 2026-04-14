using AspNetLinq.Models.Venta;

namespace AspNetLinq.Repository;

public interface IVentaRepository
{
    public IEnumerable<VentaDTO> GetVentas(int limit, int offset,int? vendedorId,int? productoId);
    
    public int GetVentasCount(int limit, int offset, int? vendedorId,int? productoId);
}