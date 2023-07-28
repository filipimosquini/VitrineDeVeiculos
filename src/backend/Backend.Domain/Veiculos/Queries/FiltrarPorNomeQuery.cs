using System.Linq.Expressions;
using Backend.Domain.Veiculos.Entities;

namespace Backend.Domain.Veiculos.Queries;

public static class FiltrarPorNomeQuery
{
    public static Expression<Func<Veiculo, bool>> Filtrar(string nome)
    {
        return veiculo => veiculo.Nome.ToLower().Contains(nome.ToLower());
    }
}