using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repositories;

public abstract class BaseGenericRepository<TEntity> : IGenericRepository<TEntity> 
    where TEntity : BaseEntity
{
     protected readonly ProjectDbContext Context;

    protected BaseGenericRepository(ProjectDbContext context)
    {
        this.Context = context;
    }
    
    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        await this.Context.AddAsync(entity);
        await this.Context.SaveChangesAsync();
        return entity;
    }

    public virtual IQueryable<TEntity> GetAll()
    {
       return this.Context.Set<TEntity>().AsQueryable();
    }

    public virtual IQueryable<TEntity> GetAllAsNoTracking()
    {
        return this.Context.Set<TEntity>().AsNoTracking();
    }

    public virtual async Task<TEntity> EditAsync(TEntity entity)
    {
        this.Context.Update(entity);
        await this.Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> DeleteAsync(TEntity entity)
    {
        this.Context.Remove(entity);
        await this.Context.SaveChangesAsync();
        return entity;
    }
}