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
    private readonly IImagemRepository _imagemRepository;
    private readonly IMapper _mapper;

    public EstudantesController(IEstudanteRepository estudanteRepository, IImagemRepository imagemRepository, IMapper mapper)
    {
        _estudanteRepository = estudanteRepository;
        _imagemRepository = imagemRepository;
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
    [Route("[controller]/{estudanteId:guid}"), ActionName(nameof(ObterEstudanteAsync))]
    public async Task<IActionResult> ObterEstudanteAsync([FromRoute] Guid estudanteId)
    {
        var estudante = await _estudanteRepository.ObterEstudanteAsync(estudanteId);

        if (estudante == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EstudanteViewModel>(estudante));
    }

    [HttpPost]
    [Route("[controller]/adicionar")]
    public async Task<IActionResult> AdicionarEstudanteAsync([FromBody] AdicionarEstudanteViewModel estudanteViewModel)
    {
        var estudante = await _estudanteRepository.AdicionarEstudanteAsync(_mapper.Map<Estudante>(estudanteViewModel));
        return CreatedAtAction(nameof(ObterEstudanteAsync), new { estudanteId = estudante.Id }, _mapper.Map<Estudante>(estudante));
    }

    [HttpPost]
    [Route("[controller]/{estudanteId:guid}/upload-imagem")]
    public async Task<IActionResult> UploadImagemAsync([FromRoute] Guid estudanteId, IFormFile imagemPerfil)
    {
        var extensoesPermitidas = new List<string> { ".jpg", ".jpeg", ".png" };

        if (imagemPerfil != null && imagemPerfil.Length > 0)
        {
            var extensaoImagem = Path.GetExtension(imagemPerfil.FileName);
            if (extensoesPermitidas.Contains(extensaoImagem.ToLower()))
            {
                if (await _estudanteRepository.Existe(estudanteId))
                {
                    var nomeArquivo = Guid.NewGuid() + Path.GetExtension(imagemPerfil.FileName);

                    var caminhoImagem = await _imagemRepository.Upload(imagemPerfil, nomeArquivo);

                    if (!await _estudanteRepository.AtualizarImagemPerfilAsync(estudanteId, caminhoImagem))
                    {
                        return Ok(caminhoImagem);
                    }
                    return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar imagem de perfil do estudante.");
                }
            }

            return BadRequest("Extensão de imagem inválida.");
        }

        return NotFound();
    }

    [HttpPut]
    [Route("[controller]/{estudanteId:guid}")]
    public async Task<IActionResult> AtualizarEstudanteAsync([FromRoute] Guid estudanteId, [FromBody] AtualizarEstudanteViewModel estudanteViewModel)
    {
        if (!await _estudanteRepository.Existe(estudanteId))
        {
            return NotFound();
        }

        var estudanteAtualizado = await _estudanteRepository.AtualizarEstudanteAsync(estudanteId, _mapper.Map<Estudante>(estudanteViewModel));

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