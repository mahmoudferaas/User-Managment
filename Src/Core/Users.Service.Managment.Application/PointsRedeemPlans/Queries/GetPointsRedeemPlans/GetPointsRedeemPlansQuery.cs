using MediatR;
using System.Collections.Generic;
using Users.Service.Managment.Application.Common.Dtos;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Queries.GetPointsRedeemPlans
{
    public class GetPointsRedeemPlansQuery : IRequest<List<PointsRedeemPlanDto>>
    {
        public string Query { get; set; }
    }
}