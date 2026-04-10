using AspNetLinq.Models.Marca;

namespace AspNetLinq.Services;

public interface IMarcaService
{
    public Marca Post (Marca marca);

    public List<Marca> GetAll(int? offset, int? limit);

    public int GetCount();
}