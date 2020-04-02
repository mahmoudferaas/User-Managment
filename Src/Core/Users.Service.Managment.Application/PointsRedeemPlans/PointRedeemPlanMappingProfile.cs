using AutoMapper;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.MarkupPlans.Commands
{
    public class PointRedeemPlanMappingProfile : Profile
    {
        public PointRedeemPlanMappingProfile()
        {
            CreateMap<CreatePointsRedeemPlanCommand, PointsRedeemPlan>().ReverseMap();
            CreateMap<UpdatePointsRedeemPlanCommand, PointsRedeemPlan>().ReverseMap();

            CreateMap<PointsRedeemPlanDto, PointsRedeemPlan>().ReverseMap();
        }
    }
}