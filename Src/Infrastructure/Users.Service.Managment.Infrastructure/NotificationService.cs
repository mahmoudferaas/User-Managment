using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
