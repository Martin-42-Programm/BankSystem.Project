using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Repositories;

public class CurrencyRepository : MetadataBaseGenericRepository<Currency>
{
    public CurrencyRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(context,
        httpContextAccessor, userManager)
    {
        
    }
}