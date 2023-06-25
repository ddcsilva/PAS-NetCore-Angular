using Microsoft.EntityFrameworkCore;
using PAS.API.Models;

namespace PAS.API.Repositories;

public class EstudanteRepository : IEstudanteRepository
{
    private readonly Context _context;

    public EstudanteRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Estudante>> ObterEstudadesAsync()
    {
        return await _context.Estudantes.Include(nameof(Genero)).Include(nameof(Endereco)).ToListAsync();
    }
}