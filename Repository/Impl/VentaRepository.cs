using AspNetLinq.Contexts;
using AspNetLinq.Excpetions;
using AspNetLinq.Models.Venta;

namespace AspNetLinq.Repository.Impl;

public class VentaRepository : IVentaRepository
{
    private readonly DataContext context;

    public VentaRepository(DataContext context)
    {
        this.context = context;
    }

    private IQueryable<VentaDTO> GetVentasQuery(int limit, int offset, int? vendedorId, int? productoId, bool count)
    {
        try
        {
            var query = context.Ventas
            .Where((v)=>v.VendedorId == vendedorId || vendedorId == null)
            .Where((v)=>v.ProductoId == productoId || productoId == null)
            .Join(context.Vendedores, (venta) => venta.VendedorId, (vendedor) => vendedor.Id,
                    (venta, vendedor) => new { venta, vendedor })
                .Join(context.Productos, (s) => s.venta.ProductoId, (producto) => producto.Id, (s,
                    producto) => new { s.venta, s.vendedor, producto })
                .Select((o) => new VentaDTO
                {
                    Id = o.venta.Id,
                    VendedorId = o.venta.VendedorId,
                    NombreVendedor = $"{o.vendedor.Nombre} {o.vendedor.Apellidos}",
                    ProductoId = o.venta.ProductoId,
                    NombreProducto = o.producto.Nombre,
                    PrecioProducto = o.producto.Precio,
                    Cantidad = o.venta.Cantidad,
                    Comentarios = o.venta.Comentarios,
                    Fecha = o.venta.Fecha,
                    Total = o.venta.Cantidad * o.producto.Precio
                    
                });
            // if (vendedorId.HasValue)
            // {
            //     query = query.Where(x=>x.VendedorId == vendedorId.Value);
            // }
            // if (productoId.HasValue)
            // {
            //     query = query.Where(x => x.ProductoId == productoId.Value);
            // }
            if (!count)
            {
                query = query.Skip(limit * offset).Take(limit);
            }
            return query;
        }
        catch (Exception e)
        {
            
            throw new CompanyException($"An error occurred at generating getVenta query {e.Message}");
        }
    }

    public IEnumerable<VentaDTO> GetVentas(int limit, int offset, int? vendedorId, int? productoId)
    {
        return GetVentasQuery(limit, offset, vendedorId, productoId, false).ToList();
    }

    public int GetVentasCount(int limit, int offset, int? vendedorId, int? productoId)
    {
        return GetVentasQuery(limit, offset, vendedorId, productoId, true).Count();
    }
}