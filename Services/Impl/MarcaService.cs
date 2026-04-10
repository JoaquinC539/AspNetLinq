using AspNetLinq.Contexts;
using AspNetLinq.Models.Marca;

namespace AspNetLinq.Services.Impl;

public class MarcaService : IMarcaService
{
    private readonly ILogger<MarcaService> _logger;
    private readonly DataContext _context;
    public MarcaService(ILogger<MarcaService> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }
    public Marca Post(Marca marca)
    {
        _context.Marcas.Add(marca);
        _context.SaveChanges();
        return marca;
    }

    public List<Marca> GetAll(int? offset, int? limit)
    {
        offset ??= 0;
        limit ??= 10;
        return _context.Marcas
            .Skip( (int)offset*(int)limit)
            .Take((int)limit)
            .ToList();
    }

    public int GetCount()
    {
        return _context.Marcas.Count();
    }
}