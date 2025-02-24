namespace BankSystem.Repositories;

public class NotificationRepository : MetadataBaseGenericRepository<Notification>
{
    public NotificationRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor) : base(context,
        httpContextAccessor)
    {
        
    }
}