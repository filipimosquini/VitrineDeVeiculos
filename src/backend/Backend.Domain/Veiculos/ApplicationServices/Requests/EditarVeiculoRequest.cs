namespace Backend.Domain.Veiculos.ApplicationServices.Requests;

public class EditarVeiculoRequest
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string MarcaId { get; set; }
    public string ModeloId { get; set; }
}