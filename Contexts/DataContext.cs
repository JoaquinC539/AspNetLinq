using AspNetLinq.Models.Marca;
using AspNetLinq.Models.Producto;
using AspNetLinq.Models.Vendedor;
using AspNetLinq.Models.Venta;
using Microsoft.EntityFrameworkCore;

namespace AspNetLinq.Contexts;

public class DataContext : DbContext
{
    public  DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    public DbSet<Vendedor> Vendedores => Set<Vendedor>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<Marca> Marcas => Set<Marca>();
}