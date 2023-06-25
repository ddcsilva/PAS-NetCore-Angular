namespace PAS.API.ViewModels;

public class AtualizarEstudanteViewModel
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public long Telefone { get; set; }
    public Guid GeneroId { get; set; }
    public string EnderecoFisico { get; set; }
    public string EnderecoPostal { get; set; }
}
