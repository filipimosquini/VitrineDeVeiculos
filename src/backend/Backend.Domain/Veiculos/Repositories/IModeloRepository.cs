using Backend.Domain.Bases.Repositories;
using Backend.Domain.Veiculos.Entities;

namespace Backend.Domain.Veiculos.Repositories;

public interface IModeloRepository : IBaseRepository<Modelo>
{
    Task<IList<Modelo>> Listar(Guid marcaId);
}