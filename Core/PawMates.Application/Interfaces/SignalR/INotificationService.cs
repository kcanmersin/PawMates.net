using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Application.Interfaces.SignalR
{
    public interface INotificationService
    {
        Task SendNotification(string message);
    }

}
