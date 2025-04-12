using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Data.Entities;

public class AuditLog : BaseEntity
{
    [Key]
    public new Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [ForeignKey("User")]
    public string UserId { get; set; }
    
    public virtual User User { get; set; }
    
    [Required]
    public string Action { get; set; }
    
    [Required]
    public string EntityType { get; set; }
    
    public string EntityId { get; set; }
    
    [Required]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    public string Details { get; set; }
    
    public string IpAddress { get; set; }
    
    public string UserAgent { get; set; }
} 