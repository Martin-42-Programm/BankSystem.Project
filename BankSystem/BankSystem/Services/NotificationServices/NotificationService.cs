using BankSystem.Data.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
namespace BankSystem.Services.NotificationServices;

public class NotificationService : INotificationService
{
    private readonly NotificationRepository _notificationRepository;
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(NotificationRepository notificationRepository, IHubContext<NotificationHub> hubContext)
    {
        _notificationRepository = notificationRepository;
        _hubContext = hubContext;
    }
    public async Task NotifyAsync(string userId, bool isSuccess, string message)
    {
        var fullMessage = isSuccess ? message + " successful!" : message + " failed!";

        var notification = new NotificationServiceModel(userId, fullMessage).ToEntity();

        await _notificationRepository.CreateAsync(notification);
        //TODO: I have to change All to userId
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", fullMessage);
    }
}