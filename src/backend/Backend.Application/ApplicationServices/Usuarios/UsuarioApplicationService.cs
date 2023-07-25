using Backend.Application.Configurations.Bases;
using Backend.Domain.Bases.ApplicationServices;
using Backend.Domain.Usuarios.ApplicationServices;
using Backend.Domain.Usuarios.Requests;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.ApplicationServices.Usuarios;

public class UsuarioApplicationService : BaseApplicationService, IUsuarioApplicationService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public UsuarioApplicationService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<ICustomValidationResult> Adicionar(AdicionarUsuarioRequest request)
    {
        var usuario = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email,
            EmailConfirmed = true
        };

        var usuarioCriado = await _userManager.CreateAsync(usuario, request.Senha);

        if (!usuarioCriado.Succeeded)
        {
            AddErrors(usuarioCriado.Errors.Select(x => x.Description));
            return CustomValidationResult;
        }

        await _signInManager.SignInAsync(usuario, false);

        return CustomValidationResult;
    }
}