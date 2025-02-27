using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Repositories;

public class CreditRepository : MetadataBaseGenericRepository<Credit>
{
    public CreditRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(context,
        httpContextAccessor, userManager)
    {
        
    }
}