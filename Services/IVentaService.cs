using AspNetLinq.Models.Venta;

namespace AspNetLinq.Services;

public interface IVentaService
{
    public Venta Post(Venta venta);

    public IEnumerable<VentaDTO> GetAll(int? limit, int? offser, int? vendedorId, int? productoId);

    public int GetCount();
}