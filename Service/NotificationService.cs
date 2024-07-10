using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class NotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyUsersAsync(string userId, string message)
    {
        await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", message);
    }
}
