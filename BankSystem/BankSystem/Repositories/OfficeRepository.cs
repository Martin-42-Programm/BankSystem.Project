using BankSystem.Data.Entities;

namespace BankSystem.Repositories;

public class OfficeRepository : MetadataBaseGenericRepository<Office>
{
    public OfficeRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }
}