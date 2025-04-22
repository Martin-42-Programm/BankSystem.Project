using BankSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Repositories;

public class AuditLogRepository : BaseGenericRepository<AuditLog>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;
    
    public AuditLogRepository(
        ProjectDbContext context, 
        IHttpContextAccessor httpContextAccessor, 
        UserManager<User> userManager) : base(context)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }
    
    public async Task<AuditLog> LogAction(string action, string entityType, string entityId, string details = null)
    {
        var user = await GetCurrentUser();
        var httpContext = _httpContextAccessor.HttpContext;
        
        var auditLog = new AuditLog
        {
            UserId = user?.Id,
            Action = action,
            EntityType = entityType,
            EntityId = entityId,
            Details = details,
            Timestamp = DateTime.UtcNow,
            IpAddress = httpContext?.Connection?.RemoteIpAddress?.ToString(),
            UserAgent = httpContext?.Request?.Headers["User-Agent"].ToString()
        };
        
        return await CreateAsync(auditLog);
      //  return auditLog;
    }
    
    public IQueryable<AuditLog> SearchLogs(
        string userId = null, 
        string action = null, 
        string entityType = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null)
    {
        var query = Context.Set<AuditLog>().AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(userId))
            query = query.Where(log => log.UserId == userId);
            
        if (!string.IsNullOrWhiteSpace(action))
            query = query.Where(log => log.Action.Contains(action));
            
        if (!string.IsNullOrWhiteSpace(entityType))
            query = query.Where(log => log.EntityType == entityType);
            
        if (startDate.HasValue)
            query = query.Where(log => log.Timestamp >= startDate.Value);
            
        if (endDate.HasValue)
            query = query.Where(log => log.Timestamp <= endDate.Value);
            
        return query.Include(log => log.User).OrderByDescending(log => log.Timestamp);
    }
    
    private async Task<User> GetCurrentUser()
    {
        if (_httpContextAccessor.HttpContext == null)
            return null;
            
        var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
        if (string.IsNullOrEmpty(userId))
            return null;
            
        return await _userManager.FindByIdAsync(userId);
    }
} 