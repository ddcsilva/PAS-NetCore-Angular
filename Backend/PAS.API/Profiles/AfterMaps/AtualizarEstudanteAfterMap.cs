using AutoMapper;
using PAS.API.Models;
using PAS.API.ViewModels;

namespace PAS.API.Profiles.AfterMaps;

public class AtualizarEstudanteAfterMap : IMappingAction<AtualizarEstudanteViewModel, Estudante>
{
    public void Process(AtualizarEstudanteViewModel source, Estudante destination, ResolutionContext context)
    {
        destination.Endereco = new Endereco()
        {
            EnderecoFisico = source.EnderecoFisico,
            EnderecoPostal = source.EnderecoPostal
        };
    }
}
