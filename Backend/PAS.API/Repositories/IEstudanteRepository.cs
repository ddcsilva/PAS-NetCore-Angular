using PAS.API.Models;

namespace PAS.API.Repositories;

public interface IEstudanteRepository {
    Task<List<Estudante>> ObterEstudadesAsync();
}