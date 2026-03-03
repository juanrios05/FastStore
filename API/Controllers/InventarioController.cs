using FastStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastStore.API.Controllers;

[ApiController]
[Route("api/inventario")]
public class InventarioController : ControllerBase
{
    private readonly IInventarioService _inventarioService;

    public InventarioController(IInventarioService inventarioService)
    {
        _inventarioService = inventarioService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _inventarioService.GetAllProductosAsync();
        return Ok(productos);
    }
    
    [HttpGet("low-stock")]
    public async Task<IActionResult> GetLowStock()
    {
        var productos = await _inventarioService.GetLowStockProductosAsync();
        return Ok(productos);
    }
}