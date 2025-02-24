namespace BankSystem.ServiceModels;

public class NotificationServiceModel
{
    //public string Id { get; set; }
    public string UserId { get; set; }
    public string Message { get; set; }

    public NotificationServiceModel(string userId, string message)
    {
        UserId = userId;
        Message = message;
    }

    public NotificationServiceModel()
    {
        
    }
}