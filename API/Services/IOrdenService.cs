using FastStore.API.DTOs;
using FastStore.API.Models;

namespace FastStore.API.Services;

public interface IOrdenService
{
    Task<OrdenReposicion> CreateOrdenAsync(CreateOrdenDto dto);
}