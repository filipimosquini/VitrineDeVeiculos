using Backend.Domain.Bases.Entities;
using Backend.Domain.Bases.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Bases;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
{
    public DbContext Context { get; }
    public IUnitOfWork UnitOfWork { get; }

    protected readonly DbSet<TEntity> DbSet;


    public BaseRepository(DbContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
        this.UnitOfWork = Context as IUnitOfWork;
    }

    public TEntity Add(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.IncluidoEm = DateTime.UtcNow;
            baseEntity.AtualizadoEm = DateTime.UtcNow;
        }

        DbSet.Add(entity);
        return entity;
    }

    public void AddRange(ICollection<TEntity> entities)
    {
        foreach (var baseEntity in entities)
        {
            if (baseEntity is BaseEntity entity)
            {
                entity.IncluidoEm = DateTime.UtcNow;
                entity.AtualizadoEm = DateTime.UtcNow;
            }
        }

        DbSet.AddRange(entities);
    }


    public TEntity Remove(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.ExcluidoEm = DateTime.UtcNow;
            DbSet.Update(entity);
        }
        else
        {
            DbSet.Remove(entity);
        }

        return entity;
    }

    public TEntity FindById(params object[] ids)
    {
        return DbSet.Find(ids);
    }

    public virtual TEntity Update(TEntity entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.AtualizadoEm = DateTime.UtcNow;
        }

        var entry = Context.Entry(entity);
        DbSet.Attach(entity);
        entry.State = EntityState.Modified;

        return entity;
    }

    public void UpdateRange(ICollection<TEntity> entities)
    {
        var _data = DateTime.UtcNow;
        foreach (var entity in entities)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.AtualizadoEm = _data;
            }

            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;

        Context.Dispose();
    }
}