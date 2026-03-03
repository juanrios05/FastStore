using FastStore.API.DTOs;
using FastStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastStore.API.Controllers;

[ApiController]
[Route("api/ordenes")]
public class OrdenesController : ControllerBase
{
    private readonly IOrdenService _ordenService;

    public OrdenesController(IOrdenService ordenService)
    {
        _ordenService = ordenService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrden([FromBody] CreateOrdenDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var orden = await _ordenService.CreateOrdenAsync(dto);
            return CreatedAtAction(nameof(CreateOrden), new { id = orden.Id }, orden);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}