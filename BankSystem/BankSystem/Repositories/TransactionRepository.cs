using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class TransactionRepository : MetadataBaseGenericRepository<Transaction>
{
    public TransactionRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }
}