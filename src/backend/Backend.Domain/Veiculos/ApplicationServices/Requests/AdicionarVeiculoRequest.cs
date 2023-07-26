namespace Backend.Domain.Veiculos.ApplicationServices.Requests;

public class AdicionarVeiculoRequest
{
    public string Nome { get; set; }
    public string MarcaId { get; set; }
    public string ModeloId { get; set; }
}