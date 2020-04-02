using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Application.Users.Commands.Create
{
    public class UserCreatedHandler : INotificationHandler<UserCreated>
    {
        private readonly INotificationService _notification;

        public UserCreatedHandler(INotificationService notification)
        {
            _notification = notification;
        }

        public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            await _notification.SendAsync(new MessageDto());
        }
    }
}