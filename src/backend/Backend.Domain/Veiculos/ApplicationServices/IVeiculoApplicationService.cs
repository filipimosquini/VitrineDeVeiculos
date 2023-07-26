using Backend.Domain.Bases.ApplicationServices;
using Backend.Domain.Veiculos.ApplicationServices.Requests;
using Backend.Domain.Veiculos.ApplicationServices.Responses;
namespace Backend.Domain.Veiculos.ApplicationServices;

public interface IVeiculoApplicationService
{
    Task<ICustomValidationResult> Adicionar(AdicionarVeiculoRequest request);
    Task<ICustomValidationResult> Editar(EditarVeiculoRequest request);
    Task<ICustomValidationResult> Excluir(Guid id);
    Task<IEnumerable<VeiculoResponse>> Listar();
    Task<IEnumerable<MarcaResponse>> ListarMarcas();
    Task<IEnumerable<ModeloResponse>> ListarModelos(Guid marcaId);
    Task<VeiculoResponse> Obter(Guid id);
}