using Backend.Domain.Autenticacao.ApplicationServices.Responses;

namespace Backend.Domain.Autenticacao.Services;

public interface IAutenticacaoService
{
    Task<AutenticacaoResponse> GerarTokenJwt(string email);
}