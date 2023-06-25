using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAS.API.Models;
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

    [HttpGet]
    [Route("[controller]/{estudanteId:guid}")]
    public async Task<IActionResult> ObterEstudanteAsync([FromRoute] Guid estudanteId)
    {
        var estudante = await _estudanteRepository.ObterEstudanteAsync(estudanteId);

        if (estudante == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EstudanteViewModel>(estudante));
    }

    [HttpPut]
    [Route("[controller]/{estudanteId:guid}")]
    public async Task<IActionResult> AtualizarEstudanteAsync([FromRoute] Guid estudanteId, [FromBody] AtualizarEstudanteViewModel request)
    {
        if (!await _estudanteRepository.Existe(estudanteId))
        {
            return NotFound();
        }

        var estudanteAtualizado = await _estudanteRepository.AtualizarEstudanteAsync(estudanteId, _mapper.Map<Estudante>(request));

        if (estudanteAtualizado == null)
        {
            return BadRequest();
        }

        return Ok(_mapper.Map<EstudanteViewModel>(estudanteAtualizado));
    }

    [HttpDelete]
    [Route("[controller]/{estudanteId:guid}")]
    public async Task<IActionResult> ExcluirEstudanteAsync([FromRoute] Guid estudanteId)
    {
        if (!await _estudanteRepository.Existe(estudanteId))
        {
            return NotFound();
        }

        var estudante = await _estudanteRepository.ExcluirEstudanteAsync(estudanteId);
        return Ok(_mapper.Map<EstudanteViewModel>(estudante));
    }
}