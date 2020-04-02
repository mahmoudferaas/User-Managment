using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Service.Managment.Application.Common.Exceptions;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Delete
{
    public class DeletePointsRedeemPlanCommandHandler : IRequestHandler<DeletePointsRedeemPlanCommand>
    {
        private readonly IUserDbContext _context;

        public DeletePointsRedeemPlanCommandHandler(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePointsRedeemPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PointsRedeemPlans.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(PointsRedeemPlan), request.Id);

           
            var hasDefaultPointsRedeemPlan = _context.DefaultPointsRedeemPlans.Any(o => o.PointsRedeemPlanId == entity.Id);
            if (hasDefaultPointsRedeemPlan)
                throw new DeleteFailureException(nameof(DefaultPointsRedeemPlan), request.Id, "There are DefaultPointsRedeemPlans orders associated with this PointsRedeemPlan.");

            var hasUserPointsRedeemPlans = _context.UserPointsRedeemPlans.Any(o => o.PointsRedeemPlanId == entity.Id);
            if (hasUserPointsRedeemPlans)
                throw new DeleteFailureException(nameof(UserPointsRedeemPlan), request.Id, "There are User orders associated with this PointsRedeemPlan.");

            _context.PointsRedeemPlans.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
