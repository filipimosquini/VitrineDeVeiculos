using Backend.Domain.Veiculos.Entities;
using System.Linq.Expressions;

namespace Backend.Domain.Veiculos.Queries;

public static class FiltrarPorModeloQuery
{
    public static Expression<Func<Veiculo, bool>> Filtrar(Guid? modeloId)
    {
        return veiculo => veiculo.ModeloId == modeloId;
    }
}