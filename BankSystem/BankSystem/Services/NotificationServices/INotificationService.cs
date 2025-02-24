namespace BankSystem.Services.NotificationServices;

public interface INotificationService
{ 
    Task NotifyAsync(string userId, bool isSuccess, string message);
}