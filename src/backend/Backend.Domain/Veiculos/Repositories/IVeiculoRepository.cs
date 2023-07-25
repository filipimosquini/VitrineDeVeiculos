using Backend.Domain.Bases.Repositories;
using Backend.Domain.Veiculos.Entities;

namespace Backend.Domain.Veiculos.Repositories;

public interface IVeiculoRepository : IBaseRepository<Veiculo>
{
    Task<IList<Veiculo>> Listar();
}