using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Service.Managment.Application.Common.Exceptions;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserDbContext _context;

        public DeleteUserCommandHandler(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            var haschildrens = _context.Users.Any(o => o.ParentUserId == entity.Id);
            if (haschildrens)
                throw new DeleteFailureException(nameof(Users), request.Id, "There are existing users associated with this user.");

            var hasMarkupPlans = _context.UserMarkupPlans.Any(o => o.UserId == entity.Id);
            if (hasMarkupPlans)
                throw new DeleteFailureException(nameof(UserMarkupPlan), request.Id, "There are MarkupPlans orders associated with this user.");

            var hasPointsRedeemPlan = _context.UserPointsRedeemPlans.Any(o => o.UserId == entity.Id);
            if (hasPointsRedeemPlan)
                throw new DeleteFailureException(nameof(PointsRedeemPlan), request.Id, "There are PointsRedeemPlan orders associated with this user.");

            _context.Users.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
