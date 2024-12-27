using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class AccountRepository : MetadataBaseGenericRepository<Account>
{
    public AccountRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) 
        : base(context, httpContextAccessor)
    {
        
    }
}