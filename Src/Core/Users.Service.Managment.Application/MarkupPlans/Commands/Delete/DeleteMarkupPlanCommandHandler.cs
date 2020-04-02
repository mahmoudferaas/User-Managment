using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Service.Managment.Application.Common.Exceptions;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.MarkupPlans.Commands.Delete
{
    public class DeleteMarkupPlanCommandHandler : IRequestHandler<DeleteMarkupPlanCommand>
    {
        private readonly IUserDbContext _context;

        public DeleteMarkupPlanCommandHandler(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMarkupPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.MarkupPlans.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(MarkupPlan), request.Id);

           
            var hasDefaultMarkupPlan = _context.DefaultMarkupPlans.Any(o => o.MarkupPlanId == entity.Id);
            if (hasDefaultMarkupPlan)
                throw new DeleteFailureException(nameof(DefaultMarkupPlan), request.Id, "There are DefaultMarkupPlans orders associated with this MarkupPlan.");

            var hasUserMarkupPlans = _context.UserMarkupPlans.Any(o => o.MarkupPlanId == entity.Id);
            if (hasUserMarkupPlans)
                throw new DeleteFailureException(nameof(UserMarkupPlan), request.Id, "There are User orders associated with this MarkupPlan.");

            _context.MarkupPlans.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
