using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Dtos;

namespace Users.Service.Managment.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
