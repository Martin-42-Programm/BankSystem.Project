using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Repositories;

public class CardRepository : MetadataBaseGenericRepository<Card>
{
    
    public CardRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(context,
        httpContextAccessor, userManager)
    {
        
    }

    
}