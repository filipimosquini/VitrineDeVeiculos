using Backend.Domain.Veiculos.Entities;
using Backend.Domain.Veiculos.Repositories;
using Backend.Infra.Bases;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repositories;

public class ModeloRepository : BaseRepository<Modelo>, IModeloRepository
{
    private readonly VitrineVeiculoContext _context;

    public ModeloRepository(VitrineVeiculoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<Modelo>> Listar(Guid marcaId)
        => await _context.Modelos
            .Where(x => x.MarcaId == marcaId)
            .ToListAsync();
}