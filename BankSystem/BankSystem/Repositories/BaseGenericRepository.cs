using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repositories;

public class BaseGenericRepository<TEntity> : IGenericRepository<TEntity> 
    where TEntity : BaseEntity
{
    protected readonly DbContext Context;

    protected BaseGenericRepository(DbContext context)
    {
        this.Context = context;
    }
    
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await this.Context.AddAsync(entity);
        await this.Context.SaveChangesAsync();
        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
       return this.Context.Set<TEntity>().AsQueryable();
    }

    public IQueryable<TEntity> GetAllAsNoTracking()
    {
        return this.Context.Set<TEntity>().AsNoTracking();
    }

    public async Task<TEntity> EditAsync(TEntity entity)
    {
        this.Context.Update(entity);
        await this.Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        this.Context.Remove(entity);
        await this.Context.SaveChangesAsync();
        return entity;
    }
}