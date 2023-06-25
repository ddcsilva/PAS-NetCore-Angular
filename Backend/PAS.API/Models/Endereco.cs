namespace PAS.API.Models;

public class Endereco
{
    public Guid Id { get; set; }
    public string EnderecoFisico { get; set; }
    public string EnderecoPostal { get; set; }

    // Propriedades de navegação
    public Guid EstudanteId { get; set; }
}