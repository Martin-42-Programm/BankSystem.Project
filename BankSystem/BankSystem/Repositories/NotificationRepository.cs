using Microsoft.AspNetCore.Identity;

namespace BankSystem.Repositories;

public class NotificationRepository : MetadataBaseGenericRepository<Notification>
{
    public NotificationRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(context,
        httpContextAccessor, userManager)
    {
        
    }
}