using AspNetLinq.Models.Venta;

namespace AspNetLinq.Services;

public interface IVentaService
{
    public Venta Post(Venta venta);
}