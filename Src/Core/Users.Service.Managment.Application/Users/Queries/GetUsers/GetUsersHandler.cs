using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Application.Common.Dtos;

namespace Users.Service.Managment.Application.Users.Queries.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserES _userES;

        public GetUsersHandler(IMapper mapper, IUserES userES)
        {
            _mapper = mapper;
            _userES = userES;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userES.GetUser(request.Query);

            var userDtos = _mapper.Map<List<UserDto>>(users);

            return userDtos;
        }
    }
}