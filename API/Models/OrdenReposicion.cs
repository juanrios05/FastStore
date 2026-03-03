namespace FastStore.API.Models;

public class OrdenReposicion
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public int Cantidad { get; set; }
    public string Estado { get; set; } = "Pendiente";

    public Producto Producto { get; set; } = null!;
}