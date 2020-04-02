using MediatR;
using System.Collections.Generic;
using Users.Service.Managment.Application.Common.Dtos;

namespace Users.Service.Managment.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
        public string Query { get; set; }
    }
}