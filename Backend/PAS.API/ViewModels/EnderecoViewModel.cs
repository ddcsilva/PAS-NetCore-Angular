namespace PAS.API.ViewModels;

public class EnderecoViewModel
{
    public Guid Id { get; set; }
    public string EnderecoFisico { get; set; }
    public string EnderecoPostal { get; set; }
    public Guid EstudanteId { get; set; }
}
