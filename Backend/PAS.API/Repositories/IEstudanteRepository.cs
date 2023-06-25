using PAS.API.Models;

namespace PAS.API.Repositories;

public interface IEstudanteRepository
{
    Task<List<Estudante>> ObterEstudadesAsync();
    Task<Estudante> ObterEstudanteAsync(Guid estudanteId);

    Task<List<Genero>> ObterGenerosAsync();
    Task<bool> Existe(Guid estudanteId);
    Task<Estudante> AdicionarEstudanteAsync(Estudante estudante);
    Task<Estudante> AtualizarEstudanteAsync(Guid estudanteId, Estudante estudante);
    Task<Estudante> ExcluirEstudanteAsync(Guid estudanteId);
}