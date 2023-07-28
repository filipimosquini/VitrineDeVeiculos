using Backend.Domain.Bases.Repositories;
using Backend.Domain.Veiculos.Entities;
using System.Linq.Expressions;

namespace Backend.Domain.Veiculos.Repositories;

public interface IVeiculoRepository : IBaseRepository<Veiculo>
{
    void Remover(Veiculo veiculo);
    Task<IList<Veiculo>> Listar(Expression<Func<Veiculo, bool>> filtro);
    Task<Veiculo?> Obter(Guid id);
}