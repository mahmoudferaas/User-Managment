using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Application.MarkupPlans.Queries.GetMarkupPlans
{
    public class GetMarkupPlansHandler : IRequestHandler<GetMarkupPlansQuery, List<MarkupPlanDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMarkupPlanES _markupPlanES;

        public GetMarkupPlansHandler(IMapper mapper, IMarkupPlanES markupPlanES)
        {
            _mapper = mapper;
            _markupPlanES = markupPlanES;
        }

        public async Task<List<MarkupPlanDto>> Handle(GetMarkupPlansQuery request, CancellationToken cancellationToken)
        {
            var markupPlans = await _markupPlanES.GetMarkupPlan(request.Query);

            var markupPlanDtos = _mapper.Map<List<MarkupPlanDto>>(markupPlans);

            return markupPlanDtos;
        }
    }
}