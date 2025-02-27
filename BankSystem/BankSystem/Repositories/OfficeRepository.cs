using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Repositories;

public class OfficeRepository : MetadataBaseGenericRepository<Office>
{
    public OfficeRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(context,
        httpContextAccessor, userManager)
    {
        
    }
}