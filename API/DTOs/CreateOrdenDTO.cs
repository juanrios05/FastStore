using System.ComponentModel.DataAnnotations;

namespace FastStore.API.DTOs;

public class CreateOrdenDto
{
    [Required]
    public int ProductoId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero.")]
    public int Cantidad { get; set; }
}