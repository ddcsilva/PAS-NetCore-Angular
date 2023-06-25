using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAS.API.Repositories;
using PAS.API.ViewModels;

namespace PAS.API.Controllers
{
    [ApiController]
    public class GenerosController : Controller
    {
        private readonly IEstudanteRepository _estudanteRepository;
        private readonly IMapper _mapper;

        public GenerosController(IEstudanteRepository estudanteRepository, IMapper mapper)
        {
            _estudanteRepository = estudanteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> ObterGeneros()
        {
            var generos = await _estudanteRepository.ObterGenerosAsync();
            
            if (generos == null || !generos.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<GeneroViewModel>>(generos));
        }
    }
}
