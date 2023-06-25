using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAS.API.Repositories;
using PAS.API.ViewModels;

namespace PAS.API.Controllers;

[ApiController]
public class EstudantesController : Controller
{
    private readonly IEstudanteRepository _estudanteRepository;
    private readonly IMapper _mapper;

    public EstudantesController(IEstudanteRepository estudanteRepository, IMapper mapper)
    {
        _estudanteRepository = estudanteRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> ObterEstudantesAsync()
    {
        var estudantes = await _estudanteRepository.ObterEstudadesAsync();
        return Ok(_mapper.Map<List<EstudanteViewModel>>(estudantes));
    }
}