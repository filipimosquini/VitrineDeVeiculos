namespace Backend.Domain.Geral;

public interface IUploadArquivoService
{
    Task<(bool Valid, IReadOnlyCollection<string> Erros)> Upload(string arquivo, string nomeDaImagem);
    Task<(bool Valid, IReadOnlyCollection<string> Erros)> Delete(string nomeDaImagem);
}