using System.Linq.Expressions;
using Backend.CrossCutting.Expressions;
using Backend.Domain.Veiculos.ApplicationServices.Requests;
using Backend.Domain.Veiculos.ApplicationServices.Responses;
using Backend.Domain.Veiculos.Entities;
using Backend.Domain.Veiculos.Queries;

namespace Backend.Domain.Veiculos.Extensions;

public static class VeiculoExtension
{
    public static Veiculo ToEntity(this AdicionarVeiculoRequest request)
    {
        if (request == null)
        {
            return null;
        }

        return new Veiculo
        {
            Nome = request.Nome,
            Valor = Math.Round(request.Valor, 2),
            MarcaId = Guid.Parse(request.MarcaId),
            ModeloId = Guid.Parse(request.ModeloId),
            Imagem = Guid.NewGuid() + "_" + request.NomeDaImagem,
        };
    }

    public static Veiculo ToEntity(this EditarVeiculoRequest request)
    {
        if (request == null)
        {
            return null;
        }

        return new Veiculo
        {
            Id = Guid.Parse(request.Id),
            Nome = request.Nome,
            Valor = Math.Round(request.Valor, 2),
            MarcaId = Guid.Parse(request.MarcaId),
            ModeloId = Guid.Parse(request.ModeloId),
            Imagem = Guid.NewGuid() + "_" + request.NomeDaImagem,
        };
    }

    public static IEnumerable<VeiculoResponse> ToResponses(this ICollection<Veiculo> veiculos)
    {
        if (veiculos is null)
        {
            return new List<VeiculoResponse>();
        }

        return veiculos.Select(x => x.ToResponse());
    }

    public static VeiculoResponse ToResponse(this Veiculo veiculo)
    {
        if (veiculo is null)
        {
            return new VeiculoResponse();
        }

        return new VeiculoResponse
        {
            Id = veiculo.Id,
            Nome = veiculo.Nome,
            Valor = veiculo.Valor,
            NomeDaImagem = veiculo.Imagem,
            Marca = veiculo.Marca.ToResponse(),
            Modelo = veiculo.Modelo.ToResponse()
        };
    }

    public static Expression<Func<Veiculo, bool>> ToExpression(this FiltrarVeiculoRequest request)
    {
        Expression<Func<Veiculo, bool>> queryBase = veiculo => 1 == 1;
        
        if (!string.IsNullOrWhiteSpace(request.Nome))
        {
            queryBase = queryBase.CombinarExpressions(FiltrarPorNomeQuery.Filtrar(request.Nome));
        }

        if (request.ValorInicio > 0 && request.ValorFim < decimal.MaxValue)
        {
            queryBase = queryBase.CombinarExpressions(FiltrarPorValorQuery.Filtrar(request.ValorInicio, request.ValorFim));
        }

        if (!string.IsNullOrWhiteSpace(request.MarcaId))
        {
            var resultado = Guid.TryParse(request.MarcaId, out var marcaId);

            if (resultado)
            {
                queryBase = queryBase.CombinarExpressions(FiltrarPorMarcaQuery.Filtrar(marcaId));
            }
        }

        if (!string.IsNullOrWhiteSpace(request.ModeloId))
        {
            var resultado = Guid.TryParse(request.ModeloId, out var modeloId);

            if (resultado)
            {
                queryBase = queryBase.CombinarExpressions(FiltrarPorModeloQuery.Filtrar(modeloId));
            }
        }

        return queryBase;
    }
}