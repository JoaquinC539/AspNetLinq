using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetLinq.Models.Vendedor;

public class Vendedor
{
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required][StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
    [Required][StringLength(50)]
    public string Apellidos { get; set; } = string.Empty;
    [Required][EmailAddress][StringLength(50)]
    public string Email { get; set; } = string.Empty;
    [StringLength(20)]
    public string CodigoEmpleado { get; init; } = string.Empty;
    
}