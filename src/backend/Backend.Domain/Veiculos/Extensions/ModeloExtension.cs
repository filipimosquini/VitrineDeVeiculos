using Backend.Domain.Veiculos.ApplicationServices.Responses;
using Backend.Domain.Veiculos.Entities;

namespace Backend.Domain.Veiculos.Extensions;

public static class ModeloExtension
{
    public static IEnumerable<ModeloResponse> ToResponseList(this ICollection<Modelo> modelos)
    {
        if (modelos == null)
        {
            return null;
        }

        return modelos.Select(x => ToResponse(x));
    }
        

    public static ModeloResponse ToResponse(this Modelo modelo)
    {
        if (modelo is null)
        {
            return null;
        }

        return new ModeloResponse
        {
            Id = modelo.Id,
            Nome = modelo.Nome,
        };
    }
}