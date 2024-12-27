using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class CurrencyRepository : MetadataBaseGenericRepository<Currency>
{
    public CurrencyRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }
    
}