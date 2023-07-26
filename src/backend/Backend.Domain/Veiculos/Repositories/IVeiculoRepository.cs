using Backend.Domain.Bases.Repositories;
using Backend.Domain.Veiculos.Entities;

namespace Backend.Domain.Veiculos.Repositories;

public interface IVeiculoRepository : IBaseRepository<Veiculo>
{
    void Remover(Veiculo veiculo);
    Task<IList<Veiculo>> Listar();
    Task<Veiculo?> Obter(Guid id);
}