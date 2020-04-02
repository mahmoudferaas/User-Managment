using MediatR;
using System.Collections.Generic;
using Users.Service.Managment.Application.Common.Dtos;

namespace Users.Service.Managment.Application.MarkupPlans.Queries.GetMarkupPlans
{
    public class GetMarkupPlansQuery : IRequest<List<MarkupPlanDto>>
    {
        public string Query { get; set; }
    }
}