using FastStore.API.Data;
using FastStore.API.DTOs;
using FastStore.API.Models;

namespace FastStore.API.Services;

public class OrdenService : IOrdenService
{
    private readonly AppDbContext _context;

    public OrdenService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OrdenReposicion> CreateOrdenAsync(CreateOrdenDto dto)
    {
        if (dto.Cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a cero.");

        var productoExiste = await _context.Productos.FindAsync(dto.ProductoId);
        if (productoExiste is null)
            throw new KeyNotFoundException($"No existe un producto con Id {dto.ProductoId}.");

        var orden = new OrdenReposicion
        {
            ProductoId      = dto.ProductoId,
            FechaSolicitud  = DateTime.UtcNow,
            Cantidad        = dto.Cantidad,
            Estado          = "Pendiente"
        };

        _context.OrdenesReposicion.Add(orden);
        await _context.SaveChangesAsync();

        return orden;
    }
}