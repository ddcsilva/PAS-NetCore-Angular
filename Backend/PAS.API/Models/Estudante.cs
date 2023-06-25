namespace PAS.API.Models;

public class Estudante
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public long Telefone { get; set; }
    public string ImagemPerfilUrl { get; set; }
    public Guid GeneroId { get; set; }

    // Propridades de navegação
    public Genero Genero { get; set; }
    public Endereco Endereco { get; set; }
}