using BankSystem.Data.Entities;

namespace BankSystem.ServiceModels;

public class AuditLogServiceModel : BaseServiceModel
{
    public Guid Id { get; set; }
    
    public string UserId { get; set; }
    
    public User User { get; set; }
    
    public string Action { get; set; }
    
    public string EntityType { get; set; }
    
    public string EntityId { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public string? Details { get; set; }
    
    public string IpAddress { get; set; }
    
    public string UserAgent { get; set; }
    
    public string UserName => User?.UserName;
    
    public string Email => User?.Email;
} 