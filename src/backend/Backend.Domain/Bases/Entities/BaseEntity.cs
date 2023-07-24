namespace Backend.Domain.Bases.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public DateTime? IncluidoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
    public DateTime? ExcluidoEm { get; set; }
}