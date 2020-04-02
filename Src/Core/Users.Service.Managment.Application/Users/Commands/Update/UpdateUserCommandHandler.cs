using AutoMapper;
using BaseClasses.Core.Utilities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Application.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);
            entity = _mapper.Map(request, entity);
            //entity.PasswordHash = LeGateSecurityHandler.HashText(request.Password);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}