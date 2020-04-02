using AutoMapper;
using BaseClasses.Core.Utilities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);
            entity.PasswordHash = LeGateSecurityHandler.HashText(request.Password);
            entity.CreationDate = DateTime.Now;
            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}