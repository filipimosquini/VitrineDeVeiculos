using Backend.Api.Bases;
using Backend.Application.Configurations;
using Backend.Application.Validators.Autenticacao;
using Backend.Domain.Autenticacao.ApplicationServices;
using Backend.Domain.Autenticacao.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/autenticacao")]
public class AutenticacaoController : MainController
{
    private readonly LoginRequestValidator _validator;
    private readonly IAutenticacaoApplicationService _applicationService;

    public AutenticacaoController(LoginRequestValidator validator, IAutenticacaoApplicationService applicationService)
    {
        _validator = validator;
        _applicationService = applicationService;
    }


    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponseError(ModelState);
        }

        var validateResult = _validator.Validate(request);
        if (validateResult.IsValid)
        {
            return CustomResponse(((CustomValidationResult)(await _applicationService.Login(request))));
        }

        return CustomResponseError(validateResult);
    }
}