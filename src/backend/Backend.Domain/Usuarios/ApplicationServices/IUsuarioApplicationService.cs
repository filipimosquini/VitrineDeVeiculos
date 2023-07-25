using Backend.Domain.Bases.ApplicationServices;
using Backend.Domain.Usuarios.Requests;

namespace Backend.Domain.Usuarios.ApplicationServices;

public interface IUsuarioApplicationService
{
    Task<ICustomValidationResult> Adicionar(AdicionarUsuarioRequest request);
}