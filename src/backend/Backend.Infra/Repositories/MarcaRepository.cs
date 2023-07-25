using Backend.Domain.Veiculos.Entities;
using Backend.Domain.Veiculos.Repositories;
using Backend.Infra.Bases;
using Backend.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repositories;

public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
{
    private readonly VitrineVeiculoContext _context;

    public MarcaRepository(VitrineVeiculoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<Marca>> Listar()
        => await _context.Marcas.ToListAsync();
}