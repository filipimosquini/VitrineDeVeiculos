using Backend.Application.Configurations.Bases;
using Backend.Domain.Veiculos.ApplicationServices;
using Backend.Domain.Veiculos.ApplicationServices.Responses;
using Backend.Domain.Veiculos.Extensions;
using Backend.Domain.Veiculos.Repositories;

namespace Backend.Application.ApplicationServices.Veiculos;

public class VeiculoApplicationService : BaseApplicationService, IVeiculoApplicationService
{
    private readonly IMarcaRepository _marcaRepository;
    private readonly IModeloRepository _modeloRepository;

    public VeiculoApplicationService(IMarcaRepository marcaRepository, IModeloRepository modeloRepository)
    {
        _marcaRepository = marcaRepository;
        _modeloRepository = modeloRepository;
    }

    public async Task<IEnumerable<MarcaResponse>> ListarMarcas()
    {
        var marcas = await _marcaRepository.Listar();

        return marcas.ToResponseList();
    }

    public async Task<IEnumerable<ModeloResponse>> ListarModelos(Guid marcaId)
    {
        var modelos = await _modeloRepository.Listar(marcaId);

        return modelos.ToResponseList();
    }
}