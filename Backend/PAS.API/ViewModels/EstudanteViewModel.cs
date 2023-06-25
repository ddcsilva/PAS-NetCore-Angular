using PAS.API.Models;

namespace PAS.API.ViewModels;

public class EstudanteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public long Telefone { get; set; }
    public string ImagemPerfilUrl { get; set; }
    public Guid GeneroId { get; set; }
    public Genero Genero { get; set; }
    public Endereco Endereco { get; set; }
}
