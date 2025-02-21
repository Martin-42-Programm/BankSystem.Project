using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class CardRepository : MetadataBaseGenericRepository<Card>
{
    
    public CardRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }

    
}