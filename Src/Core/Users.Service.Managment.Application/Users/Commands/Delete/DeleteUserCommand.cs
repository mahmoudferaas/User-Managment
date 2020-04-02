using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
       
    }
}
