using Backend.Application.Configurations.Bases;
using Backend.Domain.Geral;

namespace Backend.Application.Services.Geral;

public class UploadArquivoService : BaseService, IUploadArquivoService
{
    public async Task<(bool Valid, IReadOnlyCollection<string> Erros)> Upload(string arquivo, string nomeDaImagem)
    {
        if (string.IsNullOrEmpty(arquivo))
        {
            AddError("Forneça uma imagem para este produto!");
            return (false, Errors);
        }

        var imageDataByteArray = Convert.FromBase64String(arquivo);

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nomeDaImagem);

        if (File.Exists(filePath))
        {
            AddError("Já existe um arquivo com este nome!");
            return (false, Errors);
        }

        File.WriteAllBytes(filePath, imageDataByteArray);

        return (true, Errors);
    }

    public async Task<(bool Valid, IReadOnlyCollection<string> Erros)> Delete(string nomeDaImagem)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nomeDaImagem);

        if (!File.Exists(filePath))
        {
            AddError("O arquivo não foi encontrado!");
            return (false, Errors);
        }

        File.Delete(filePath);

        return (true, Errors);
    }
}