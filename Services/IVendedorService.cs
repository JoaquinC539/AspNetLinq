using AspNetLinq.Models.Vendedor;

namespace AspNetLinq.Services;

public interface IVendedorService
{
    public Vendedor Post (Vendedor vendedor);
}