using AutoMapper;
using PAS.API.Models;
using PAS.API.ViewModels;

namespace PAS.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Estudante, EstudanteViewModel>().ReverseMap();   
            CreateMap<Genero, GeneroViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();         
        }
    }
}