using AutoMapper;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.MarkupPlans.Commands.Create;
using Users.Service.Managment.Application.MarkupPlans.Commands.Update;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.MarkupPlans.Commands
{
    public class MarkupPlanMappingProfile : Profile
    {
        public MarkupPlanMappingProfile()
        {
            CreateMap<CreateMarkupPlanCommand, MarkupPlan>().ReverseMap();
            CreateMap<UpdateMarkupPlanCommand, MarkupPlan>().ReverseMap();

            CreateMap<MarkupPlanDto, MarkupPlan>().ReverseMap();


        }
    }
}
