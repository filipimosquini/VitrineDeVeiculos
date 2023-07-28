namespace Backend.Domain.Veiculos.ApplicationServices.Requests;

public class FiltrarVeiculoRequest
{
    public string Nome { get; set; } = string.Empty;
    public decimal ValorInicio { get; set; } = decimal.Zero;
    public decimal ValorFim { get; set; } = decimal.MaxValue;
    public string MarcaId { get; set; } = string.Empty;
    public string ModeloId { get; set; } = string.Empty;
}