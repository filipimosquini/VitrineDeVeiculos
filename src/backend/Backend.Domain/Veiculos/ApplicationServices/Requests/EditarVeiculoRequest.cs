namespace Backend.Domain.Veiculos.ApplicationServices.Requests;

public class EditarVeiculoRequest
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public string MarcaId { get; set; }
    public string ModeloId { get; set; }
    public string UploadDaImagem { get; set; }
    public string NomeDaImagem { get; set; }
}