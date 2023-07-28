using Backend.Domain.Veiculos.Entities;
using System.Linq.Expressions;

namespace Backend.Domain.Veiculos.Queries;

public static class FiltrarPorValorQuery
{
    public static Expression<Func<Veiculo, bool>> Filtrar(decimal valorInicial, decimal valorFinal)
    {
        return veiculo => veiculo.Valor >= valorInicial && veiculo.Valor <= valorFinal;
    }
}