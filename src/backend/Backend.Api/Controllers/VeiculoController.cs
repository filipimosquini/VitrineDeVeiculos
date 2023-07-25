using Backend.Api.Bases;
using Backend.Domain.Veiculos.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/veiculos")]
public class VeiculoController : MainController
{
    private readonly IVeiculoApplicationService _applicationService;

    public VeiculoController(IVeiculoApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet("marcas")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListarMarcas()
    {
        return CustomResponse(await _applicationService.ListarMarcas());
    }

    [HttpGet("modelos/{marcaId}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListarModelos(Guid marcaId)
    {
        return CustomResponse(await _applicationService.ListarModelos(marcaId));
    }
}