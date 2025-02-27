using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Data.Entities;

public class Notification : MetadataBaseEntity
{
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual User User { get; set; }
    public string Message { get; set; }
    

    public Notification()
    {
        
    }

    public Notification(Guid userId, string message)
    {
        Id = Guid.NewGuid();
        UserId = userId.ToString();
        Message = message;
    }

}