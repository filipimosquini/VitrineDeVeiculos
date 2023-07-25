using Backend.Domain.Bases.Entities;

namespace Backend.Domain.Veiculos.Entities;

public class Modelo: BaseEntity
{
    public string Nome { get; set; }
    public Guid? MarcaId { get; set; }

    /* EF Relation */
    public Marca? Marca { get; set; }
    public ICollection<Veiculo>? Veiculos { get; set; }
}