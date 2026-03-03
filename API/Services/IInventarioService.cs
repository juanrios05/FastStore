using FastStore.API.DTOs;

namespace FastStore.API.Services;

public interface IInventarioService
{
    Task<IEnumerable<ProductoDto>> GetAllProductosAsync();
    Task<IEnumerable<ProductoDto>> GetLowStockProductosAsync();
}