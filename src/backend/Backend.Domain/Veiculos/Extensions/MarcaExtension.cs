using Backend.Domain.Veiculos.ApplicationServices.Responses;
using Backend.Domain.Veiculos.Entities;

namespace Backend.Domain.Veiculos.Extensions;

public static class MarcaExtension
{
    public static IEnumerable<MarcaResponse> ToResponseList(this ICollection<Marca> marcas)
    {
        if (marcas == null)
        {
            return null;
        }

        return marcas.Select(x => ToResponse(x));
    }

    public static MarcaResponse ToResponse(this Marca marca)
    {
        if (marca is null)
        {
            return null;
        }

        return new MarcaResponse
        {
            Id = marca.Id,
            Nome = marca.Nome,
        };
    }
}