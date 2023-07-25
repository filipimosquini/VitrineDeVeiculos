using Backend.Application.Configurations.Bases;
using Backend.Domain.Autenticacao.ApplicationServices;
using Backend.Domain.Autenticacao.Requests;
using Backend.Domain.Autenticacao.Services;
using Backend.Domain.Bases.ApplicationServices;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.ApplicationServices.Autenticacao;

public class AutenticacaoApplicationService : BaseApplicationService, IAutenticacaoApplicationService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IAutenticacaoService _autenticacaoService;

    public AutenticacaoApplicationService(SignInManager<IdentityUser> signInManager, IAutenticacaoService autenticacaoService)
    {
        _signInManager = signInManager;
        _autenticacaoService = autenticacaoService;
    }

    public async Task<ICustomValidationResult> Login(LoginRequest request)
    {
        var resultado = await _signInManager.PasswordSignInAsync(request.Email, request.Senha, false, true);

        if (resultado.IsLockedOut)
        {
            AddError("Usuário temporariamente bloqueado por tentativas inválidas");
        }

        if (resultado.IsNotAllowed)
        {
            AddError("Login não permitido");
        }

        if (!resultado.Succeeded)
        {
            AddError("Login ou senha incorretos");
        }

        if (!CustomValidationResult.IsValid)
        {
            return CustomValidationResult;
        }

        CustomValidationResult.Data = await _autenticacaoService.GerarTokenJwt(request.Email);

        return CustomValidationResult;
    }
}