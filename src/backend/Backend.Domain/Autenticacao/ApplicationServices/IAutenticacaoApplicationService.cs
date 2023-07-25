using Backend.Domain.Autenticacao.Requests;
using Backend.Domain.Bases.ApplicationServices;

namespace Backend.Domain.Autenticacao.ApplicationServices;

public interface IAutenticacaoApplicationService
{
    Task<ICustomValidationResult> Login(LoginRequest request);
}