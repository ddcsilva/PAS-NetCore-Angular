namespace PAS.API.Repositories;

public interface IImagemRepository
{
    Task<string> Upload(IFormFile arquivo, string nomeArquivo);
}