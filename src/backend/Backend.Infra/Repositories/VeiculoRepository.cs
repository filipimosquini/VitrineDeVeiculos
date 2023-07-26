using Backend.Domain.Veiculos.Entities;
using Backend.Domain.Veiculos.Repositories;
using Backend.Infra.Bases;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repositories;

public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
{
    private readonly VitrineVeiculoContext _context;

    public VeiculoRepository(VitrineVeiculoContext context) : base(context)
    {
        _context = context;
    }

    public void Remover(Veiculo veiculo)
    {
        _context.Veiculos.Remove(veiculo);
    }

    public async Task<IList<Veiculo>> Listar()
        => await _context.Veiculos
            .Include(x => x.Marca)
            .Include(x => x.Modelo)
            .ToListAsync();
}