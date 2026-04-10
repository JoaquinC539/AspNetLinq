using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace AspNetLinq.Models.Venta;

public class Venta
{
    [Key]
    public int Id { get; set; }
    [Required][BindRequired]
    public int VendedorId { get; set; }
    [Required][BindRequired][Range(1, int.MaxValue)]
    public int ProductoId { get; set; }
    [Required][BindRequired][Range(1, int.MaxValue)]
    public int Cantidad { get; set; } 
    [StringLength(300)]
    public string? Comentarios { get; set; } = string.Empty;
    public DateTime Fecha { get;set; }  = DateTime.Today; 
}