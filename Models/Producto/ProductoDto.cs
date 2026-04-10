namespace AspNetLinq.Models.Producto;

public class ProductoDto
{
    public int Id { get; set; }
    
    public string CodigoProducto { get; set; } = string.Empty;
    
    public string Nombre { get; set; } = string.Empty;
    
    public double Precio { get; set; }
    
    public string Descripcion { get; set; } = string.Empty;
    
    public int MarcaId { get; set; }
    
    public string MarcaNombre { get; set; } = string.Empty;
    
}