using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Repositories;

public class TransactionRepository : MetadataBaseGenericRepository<Transaction>
{
    public TransactionRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(context,
        httpContextAccessor, userManager)
    {
        
    }
}