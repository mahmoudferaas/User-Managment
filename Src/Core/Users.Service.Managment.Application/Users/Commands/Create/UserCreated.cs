using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Service.Managment.Application.Users.Commands.Create
{
    public class UserCreated : INotification
    {
        public Guid UserId { get; set; }
    }
}
