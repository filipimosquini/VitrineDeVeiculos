namespace Backend.Domain.Bases.Repositories;

public interface IUnitOfWork
{
    Task<bool> Commit();
    bool DatabaseExists();
}