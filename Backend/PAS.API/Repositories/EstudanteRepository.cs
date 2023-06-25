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

    public async Task<Estudante> ObterEstudanteAsync(Guid estudanteId)
    {
        return await _context.Estudantes.Include(nameof(Genero)).Include(nameof(Endereco)).FirstOrDefaultAsync(x => x.Id == estudanteId);
    }

    public async Task<List<Genero>> ObterGenerosAsync()
    {
        return await _context.Generos.ToListAsync();
    }

    public async Task<bool> Existe(Guid estudanteId)
    {
        return await _context.Estudantes.AnyAsync(x => x.Id == estudanteId);
    }

    public async Task<Estudante> AtualizarEstudanteAsync(Guid estudanteId, Estudante estudante)
    {
        var estudanteEncontrado = await ObterEstudanteAsync(estudanteId);

        if (estudanteEncontrado != null)
        {
            estudanteEncontrado.Nome = estudante.Nome;
            estudanteEncontrado.Sobrenome = estudante.Sobrenome;
            estudanteEncontrado.DataNascimento = estudante.DataNascimento;
            estudanteEncontrado.Email = estudante.Email;
            estudanteEncontrado.Telefone = estudante.Telefone;
            estudanteEncontrado.GeneroId = estudante.GeneroId;
            estudanteEncontrado.Endereco.EnderecoFisico = estudante.Endereco.EnderecoFisico;
            estudanteEncontrado.Endereco.EnderecoPostal = estudante.Endereco.EnderecoPostal;

            await _context.SaveChangesAsync();
            return estudanteEncontrado;
        }

        return null;
    }

    public async Task<Estudante> ExcluirEstudanteAsync(Guid estudanteId)
    {
        var estudanteEncontrado = await ObterEstudanteAsync(estudanteId);

        if (estudanteEncontrado != null)
        {
            _context.Estudantes.Remove(estudanteEncontrado);
            await _context.SaveChangesAsync();
            return estudanteEncontrado;
        }

        return null;
    }
}