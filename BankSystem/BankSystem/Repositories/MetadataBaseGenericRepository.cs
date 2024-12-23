using System.Runtime.CompilerServices;
using System.Security.Claims;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repositories;

public abstract class MetadataBaseGenericRepository<TEntity> : BaseGenericRepository<TEntity>
where TEntity : MetadataBaseEntity
{
    private readonly IHttpContextAccessor httpContextAccessor;
    
    protected MetadataBaseGenericRepository(ProjectDbContext Context, IHttpContextAccessor httpContextAccessor) : base(Context)
    {
        
        this.httpContextAccessor = httpContextAccessor;
    }

    
    public override async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.CreatedBy = await this.GetCurrentUser();
        return await base.CreateAsync(entity);
    }
    
    public override async Task<TEntity> EditAsync(TEntity entity)
    {
        entity.ModifiedDate = DateTime.UtcNow;
        entity.ModifiedBy = await this.GetCurrentUser();
        return await base.EditAsync(entity);
        
    }
    
    public override async Task<TEntity> DeleteAsync(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow;
        entity.DeletedBy = await this.GetCurrentUser();
        return await base.DeleteAsync(entity);
    }

    protected async Task<User> GetCurrentUser()
    {
        string userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        return await this.Context.Users.SingleOrDefaultAsync(user => user.Id == userId);
    }
}