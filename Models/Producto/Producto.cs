using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetLinq.Models.Producto;

public class Producto
{ 
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(20)]
    public string CodigoProducto { get; set; } = string.Empty;
    [Required][StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
    [Required][BindRequired][Range(1, int.MaxValue)]
    public int MarcaId { get; set; }
    [Required]
    public double Precio { get; set; }
    [Required][StringLength(500)]
    public string Descripcion { get; set; } = string.Empty;
    
    
    
    
}