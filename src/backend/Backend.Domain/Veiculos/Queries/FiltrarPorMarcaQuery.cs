using Backend.Domain.Veiculos.Entities;
using System.Linq.Expressions;

namespace Backend.Domain.Veiculos.Queries;

public static class FiltrarPorMarcaQuery
{
    public static Expression<Func<Veiculo, bool>> Filtrar(Guid? marcaId)
    {
        return veiculo => veiculo.MarcaId == marcaId;
    }
}