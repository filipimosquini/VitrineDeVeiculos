using Backend.Application.Configurations.Bases;
using Backend.Domain.Bases.ApplicationServices;
using Backend.Domain.Veiculos.ApplicationServices;
using Backend.Domain.Veiculos.ApplicationServices.Requests;
using Backend.Domain.Veiculos.ApplicationServices.Responses;
using Backend.Domain.Veiculos.Entities;
using Backend.Domain.Veiculos.Extensions;
using Backend.Domain.Veiculos.Repositories;

namespace Backend.Application.ApplicationServices.Veiculos;

public class VeiculoApplicationService : BaseApplicationService, IVeiculoApplicationService
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMarcaRepository _marcaRepository;
    private readonly IModeloRepository _modeloRepository;

    public VeiculoApplicationService(IMarcaRepository marcaRepository, IModeloRepository modeloRepository, IVeiculoRepository veiculoRepository)
    {
        _marcaRepository = marcaRepository;
        _modeloRepository = modeloRepository;
        _veiculoRepository = veiculoRepository;
    }

    public async Task<ICustomValidationResult> Adicionar(AdicionarVeiculoRequest request)
    {
        var veiculo = request.ToEntity();

        await _veiculoRepository.AddAsync(veiculo);

        await CommitAsync(_veiculoRepository.UnitOfWork);

        return CustomValidationResult;
    }

    public async Task<ICustomValidationResult> Editar(EditarVeiculoRequest request)
    {
        var veiculo = await _veiculoRepository.FindById(Guid.Parse(request.Id));

        if (veiculo is null)
        {
            AddError("Veículo não encontrado");
            return CustomValidationResult;
        }

        veiculo.Nome = request.Nome;
        veiculo.Valor = request.Valor;
        veiculo.MarcaId = Guid.Parse(request.MarcaId);
        veiculo.ModeloId = Guid.Parse(request.ModeloId);

        _veiculoRepository.Update(veiculo);

        await CommitAsync(_veiculoRepository.UnitOfWork);

        return CustomValidationResult;
    }

    public async Task<ICustomValidationResult> Excluir(Guid id)
    {
        var veiculo = await _veiculoRepository.FindById(id);

        if (veiculo is null)
        {
            AddError("Veículo não encontrado");
            return CustomValidationResult;
        }

        _veiculoRepository.Remover(veiculo);

        await CommitAsync(_veiculoRepository.UnitOfWork);

        return CustomValidationResult;
    }

    public async Task<IEnumerable<VeiculoResponse>> Listar()
    {
        var veiculos = await _veiculoRepository.Listar();

        return veiculos.ToResponses();
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

    public async Task<VeiculoResponse> Obter(Guid id)
    {
        var veiculo = await _veiculoRepository.Obter(id);

        return veiculo.ToResponse();
    }
}