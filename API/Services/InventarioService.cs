using FastStore.API.Data;
using FastStore.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FastStore.API.Services;

public class InventarioService : IInventarioService
{
    private readonly AppDbContext _context;

    public InventarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductoDto>> GetAllProductosAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria.Nombre
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductoDto>> GetLowStockProductosAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.StockActual < p.StockMinimo)
            .Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                CategoriaId = p.CategoriaId,
                CategoriaNombre = p.Categoria.Nombre
            })
            .ToListAsync();
    }
}