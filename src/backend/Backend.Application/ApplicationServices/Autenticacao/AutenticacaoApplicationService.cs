using Backend.Application.Configurations.Bases;
using Backend.Domain.Autenticacao.ApplicationServices;
using Backend.Domain.Autenticacao.Requests;
using Backend.Domain.Bases.ApplicationServices;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.ApplicationServices.Autenticacao;

public class AutenticacaoApplicationService : BaseApplicationService, IAutenticacaoApplicationService
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AutenticacaoApplicationService(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<ICustomValidationResult> Login(LoginRequest request)
    {
        var resultado = await _signInManager.PasswordSignInAsync(request.Email, request.Senha, false, true);

        if (resultado.IsLockedOut)
        {
            AddError("Usuário bloqueado por tentativas incorretas de login");
        }

        if (resultado.IsNotAllowed)
        {
            AddError("Login não permitido");
        }

        if (!resultado.Succeeded)
        {
            AddError("Login ou senha incorretos");
        }

        return CustomValidationResult;
    }
}