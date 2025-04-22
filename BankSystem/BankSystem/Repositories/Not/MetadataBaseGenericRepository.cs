using System.Runtime.CompilerServices;
using System.Security.Claims;
using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repositories;

public abstract class MetadataBaseGenericRepository<TEntity> : BaseGenericRepository<TEntity>
where TEntity : MetadataBaseEntity
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly UserManager<User> userManager;
    
    protected MetadataBaseGenericRepository(ProjectDbContext Context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(Context)
    {
        
        this.httpContextAccessor = httpContextAccessor;
        this.userManager = userManager;
    }

    
    public override async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow.AddHours(2);
        entity.CreatedBy = await this.GetCurrentUser();
        return await base.CreateAsync(entity);
    }
    
    public override async Task<TEntity> EditAsync(TEntity entity)
    {
        entity.ModifiedDate = DateTime.UtcNow.AddHours(2);
        entity.ModifiedBy = await this.GetCurrentUser();
        return await base.EditAsync(entity);
        
    }
    
    public override  async Task<TEntity> DeleteAsync(TEntity entity)
    {
        entity.DeletedDate = DateTime.UtcNow.AddHours(2);
        entity.DeletedBy = await this.GetCurrentUser();
        return  await base.DeleteAsync(entity);
    }

    protected async Task<User> GetCurrentUser()
    {
        var userId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var user = await userManager.FindByIdAsync(userId);
        
        return await this.Context.Users.SingleOrDefaultAsync(user => user.Id == userId);
         var existingUser = await this.Context.Users
             .FirstOrDefaultAsync(user => user.Id == "00000000-0000-0000-0000-000000000006");  // Use a fixed GUID for consistency
        
         // If the user does not exist, create a new one and return it
         if (existingUser != null)
         {
             return existingUser;  // Return the existing user
         }
        // var user = new User
        //  {
        //      Id = "00000000-0000-0000-0000-000000000006",  // Use a fixed GUID for consistency.
        //      UserName = "SystemUser"
        //  };
        // this.Context.Entry(user).State = EntityState.Detached;
         return user;
    }
}