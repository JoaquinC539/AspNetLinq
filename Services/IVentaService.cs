using AspNetLinq.Models.Venta;

namespace AspNetLinq.Services;

public interface IVentaService
{
    public Venta Post(Venta venta);

    public IEnumerable<VentaDTO> GetAll(int? limit, int? offset, int? vendedorId, int? productoId);

    public int GetCount(int? limit, int? offset, int? vendedorId, int? productoId);
}