using AspNetLinq.Models.Vendedor;

namespace AspNetLinq.Services;

public interface IVendedorService
{
    public Vendedor Post (Vendedor vendedor);
    
    public List<Vendedor> GetAll(int? limit = 10, int? offset = 0);

    public int GetCount();


}