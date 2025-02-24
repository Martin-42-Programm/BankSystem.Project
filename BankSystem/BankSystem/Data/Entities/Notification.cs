namespace BankSystem.Data.Entities;

public class Notification : MetadataBaseEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Message { get; set; }
    

    public Notification()
    {
        
    }

    public Notification(Guid userId, string message)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Message = message;
    }

}