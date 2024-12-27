using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class CreditRepository : MetadataBaseGenericRepository<Credit>
{
    public CreditRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }
}