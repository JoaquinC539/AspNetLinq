namespace AspNetLinq.Models.Venta;

public class VentaDTO : Venta
{
    
    public double Total { get; set; }
    public string NombreVendedor { get; set; }
    public string NombreProducto { get; set; }
    
}