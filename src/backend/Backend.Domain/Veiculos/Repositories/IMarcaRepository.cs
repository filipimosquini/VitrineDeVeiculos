using Backend.Domain.Bases.Repositories;
using Backend.Domain.Veiculos.Entities;

namespace Backend.Domain.Veiculos.Repositories;

public interface IMarcaRepository : IBaseRepository<Marca>
{
    Task<IList<Marca>> Listar();
}