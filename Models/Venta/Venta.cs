using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AspNetLinq.Models.Venta;

public class Venta
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int VendedorId { get; set; }
    [Required]
    public int ProductoId { get; set; }
    [Required]
    public int Cantidad { get; set; } 
    [StringLength(300)]
    public string? Comentarios { get; set; } = string.Empty;
    public DateTime Fecha { get;init; } 
}