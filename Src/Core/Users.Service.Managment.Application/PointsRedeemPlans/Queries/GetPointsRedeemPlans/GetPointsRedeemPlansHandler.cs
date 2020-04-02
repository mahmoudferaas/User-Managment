using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Queries.GetPointsRedeemPlans
{
    public class GetPointsRedeemPlansHandler : IRequestHandler<GetPointsRedeemPlansQuery, List<PointsRedeemPlanDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPointRedeemPlanES _pointRedeemPlanES;

        public GetPointsRedeemPlansHandler(IMapper mapper, IPointRedeemPlanES pointRedeemPlanES)
        {
            _mapper = mapper;
            _pointRedeemPlanES = pointRedeemPlanES;
        }

        public async Task<List<PointsRedeemPlanDto>> Handle(GetPointsRedeemPlansQuery request, CancellationToken cancellationToken)
        {
            var PointsRedeemPlans = await _pointRedeemPlanES.GetPointRedeemPlan(request.Query);
            var PointsRedeemPlanDtos = _mapper.Map<List<PointsRedeemPlanDto>>(PointsRedeemPlans);
            return PointsRedeemPlanDtos;
        }
    }
}