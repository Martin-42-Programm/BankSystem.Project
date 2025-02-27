using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
namespace BankSystem.Services.NotificationServices;

public class NotificationHub : Hub
{
    public async Task SendNotification(string userId, string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", message);
    }
}