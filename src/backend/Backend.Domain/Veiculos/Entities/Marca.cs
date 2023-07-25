using Backend.Domain.Bases.Entities;

namespace Backend.Domain.Veiculos.Entities;

public class Marca : BaseEntity
{
    public string Nome { get; set; }

    /* EF Relation */
    public ICollection<Modelo>? Modelos { get; set; }
    public ICollection<Veiculo>? Veiculos { get; set; }
}