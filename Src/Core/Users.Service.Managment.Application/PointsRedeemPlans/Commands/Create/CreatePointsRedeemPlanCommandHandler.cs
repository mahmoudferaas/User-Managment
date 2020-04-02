using AutoMapper;
using BaseClasses.Core.Utilities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create
{
    public class CreatePointsRedeemPlanCommandHandler : IRequestHandler<CreatePointsRedeemPlanCommand, int>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public CreatePointsRedeemPlanCommandHandler(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePointsRedeemPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PointsRedeemPlan>(request);
            _context.PointsRedeemPlans.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}