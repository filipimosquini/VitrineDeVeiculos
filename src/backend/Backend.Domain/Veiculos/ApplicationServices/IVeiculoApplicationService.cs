using Backend.Domain.Veiculos.ApplicationServices.Responses;

namespace Backend.Domain.Veiculos.ApplicationServices;

public interface IVeiculoApplicationService
{
    Task<IEnumerable<MarcaResponse>> ListarMarcas();
    Task<IEnumerable<ModeloResponse>> ListarModelos(Guid marcaId);
}