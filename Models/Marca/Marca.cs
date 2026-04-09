using System.ComponentModel.DataAnnotations;

namespace AspNetLinq.Models.Marca;

public class Marca
{
    [Key]
    public int Id { get; set; }
    [Required][StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
}