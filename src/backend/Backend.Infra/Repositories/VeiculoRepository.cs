using Backend.Domain.Veiculos.Entities;
using Backend.Domain.Veiculos.Repositories;
using Backend.Infra.Bases;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<IList<Veiculo>> Listar(Expression<Func<Veiculo, bool>> filtro)
    => await _context.Veiculos
            .Include(x => x.Marca)
            .Include(x => x.Modelo)
            .Where(filtro)
            .OrderByDescending(x => x.Valor)
            .ToListAsync();
    

    public async Task<Veiculo?> Obter(Guid id)
        => await _context.Veiculos
            .Include(x => x.Marca)
            .Include(x => x.Modelo)
            .FirstOrDefaultAsync(x => x.Id == id);
}