namespace PAS.API.Repositories;

public class ImagemLocalStorageRepository : IImagemRepository
{
    public async Task<string> Upload(IFormFile arquivo, string nomeArquivo)
    {
        var caminho = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images", nomeArquivo);

        using Stream stream = new FileStream(caminho, FileMode.Create);
        await arquivo.CopyToAsync(stream);

        return ObterCaminhoServidor(nomeArquivo);
    }

    private string ObterCaminhoServidor(string nomeArquivo)
    {
        return Path.Combine(@"Resources\Images", nomeArquivo);
    }
}