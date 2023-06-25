using AutoMapper;
using PAS.API.Models;
using PAS.API.ViewModels;

namespace PAS.API.Profiles.AfterMaps;

public class AdicionarEstudanteAfterMap : IMappingAction<AdicionarEstudanteViewModel, Estudante>
{
    public void Process(AdicionarEstudanteViewModel source, Estudante destination, ResolutionContext context)
    {
        destination.Id = Guid.NewGuid();
        destination.Endereco = new Endereco()
        {
            Id = Guid.NewGuid(),
            EnderecoFisico = source.EnderecoFisico,
            EnderecoPostal = source.EnderecoPostal
        };
    }
}
