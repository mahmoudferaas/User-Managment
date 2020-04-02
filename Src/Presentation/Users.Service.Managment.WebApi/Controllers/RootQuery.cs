using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.MarkupPlans.Queries.GetMarkupPlans;
using Users.Service.Managment.Application.PointsRedeemPlans.Queries.GetPointsRedeemPlans;
using Users.Service.Managment.Application.Users.Queries.GetUsers;

namespace Users.Service.Managment.WebApi.Controllers
{
    public class RootQuery
    {
        private readonly IMediator _mediator;

        public RootQuery(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<UserDto>> GetUser(GetUsersQuery args)
        {
            return await _mediator.Send(args);
        }

        public async Task<List<MarkupPlanDto>> GetMarkupPlan(GetMarkupPlansQuery args)
        {
            return await _mediator.Send(args);
        }

        public async Task<List<PointsRedeemPlanDto>> GetPointsRedeemPlan(GetPointsRedeemPlansQuery args)
        {
            return await _mediator.Send(args);
        }
    }
}