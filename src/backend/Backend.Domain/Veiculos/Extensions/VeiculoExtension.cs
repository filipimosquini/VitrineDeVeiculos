using Backend.Domain.Veiculos.ApplicationServices.Requests;
using Backend.Domain.Veiculos.ApplicationServices.Responses;
using Backend.Domain.Veiculos.Entities;

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
}