using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetLinq.Models.Producto;

public class Producto
{ 
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(20)]
    public string CodigoProducto { get; set; } = string.Empty;
    [Required][StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public int MarcaId { get; set; }
    [Required][StringLength(200)]
    public string Descripcion { get; set; } = string.Empty;
    
    
}