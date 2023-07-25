using Backend.Domain.Bases.Entities;

namespace Backend.Domain.Veiculos.Entities;

public class Veiculo : BaseEntity
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public string Imagem { get; set; }
    public Guid? MarcaId { get; set; }
    public Guid? ModeloId { get; set; }

    /* EF Relations */
    public Marca? Marca { get; set; }
    public Modelo? Modelo { get; set; }
}