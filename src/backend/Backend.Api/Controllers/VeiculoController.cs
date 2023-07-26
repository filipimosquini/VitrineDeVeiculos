using Backend.Api.Bases;
using Backend.Application.Configurations;
using Backend.Application.Validators.Veiculos;
using Backend.Domain.Veiculos.ApplicationServices;
using Backend.Domain.Veiculos.ApplicationServices.Requests;
using Backend.Domain.Veiculos.ApplicationServices.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/veiculos")]
public class VeiculoController : MainController
{
    private readonly AdicionarVeiculoRequestValidator _adicionarVeiculoRequestValidator;
    private readonly EditarVeiculoRequestValidator _editarVeiculoRequestValidator;

    private readonly IVeiculoApplicationService _applicationService;

    public VeiculoController(IVeiculoApplicationService applicationService, AdicionarVeiculoRequestValidator adicionarVeiculoRequestValidator, EditarVeiculoRequestValidator editarVeiculoRequestValidator)
    {
        _applicationService = applicationService;
        _adicionarVeiculoRequestValidator = adicionarVeiculoRequestValidator;
        _editarVeiculoRequestValidator = editarVeiculoRequestValidator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarVeiculoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponseError(ModelState);
        }

        var validateResult = _adicionarVeiculoRequestValidator.Validate(request);
        if (validateResult.IsValid)
        {
            return CustomResponse((CustomValidationResult)await _applicationService.Adicionar(request));
        }

        return CustomResponseError(validateResult);
    }

    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Alterar([FromBody] EditarVeiculoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponseError(ModelState);
        }

        var validateResult = _editarVeiculoRequestValidator.Validate(request);
        if (validateResult.IsValid)
        {
            return CustomResponse((CustomValidationResult)await _applicationService.Editar(request));
        }

        return CustomResponseError(validateResult);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remover(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponseError(ModelState);
        }

        return CustomResponse((CustomValidationResult)await _applicationService.Excluir(id));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VeiculoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Listar()
    {
        return CustomResponse(await _applicationService.Listar());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(VeiculoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Obter(Guid id)
    {
        return CustomResponse(await _applicationService.Obter(id));
    }

    [HttpGet("marcas")]
    [ProducesResponseType(typeof(IEnumerable<MarcaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListarMarcas()
    {
        return CustomResponse(await _applicationService.ListarMarcas());
    }

    [HttpGet("modelos/{marcaId}")]
    [ProducesResponseType(typeof(IEnumerable<ModeloResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListarModelos(Guid marcaId)
    {
        return CustomResponse(await _applicationService.ListarModelos(marcaId));
    }
}