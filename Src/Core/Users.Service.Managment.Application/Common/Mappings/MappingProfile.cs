using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.MarkupPlans.Commands.Create;
using Users.Service.Managment.Application.MarkupPlans.Commands.Update;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create;
using Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update;
using Users.Service.Managment.Application.Users.Commands.Create;
using Users.Service.Managment.Application.Users.Commands.Update;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

            CreateMap<CreateMarkupPlanCommand, MarkupPlan>().ReverseMap();
            CreateMap<UpdateMarkupPlanCommand, MarkupPlan>().ReverseMap();

            CreateMap<MarkupPlanDto, MarkupPlan>().ReverseMap();

            CreateMap<CreatePointsRedeemPlanCommand, PointsRedeemPlan>().ReverseMap();
            CreateMap<UpdatePointsRedeemPlanCommand, PointsRedeemPlan>().ReverseMap();

            CreateMap<PointsRedeemPlanDto, PointsRedeemPlan>().ReverseMap();

            CreateMap<CreateUserCommand, User>().ForMember(m => m.ParentUserId, action => action.Condition(c => c.ParentUserId != Guid.Empty));
            CreateMap<User, CreateUserCommand>();

            CreateMap<UpdateUserCommand, User>().ForMember(m => m.ParentUserId, action => action.Condition(c => c.ParentUserId != Guid.Empty));
            CreateMap<User, UpdateUserCommand>();

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreditCardDto, UserCreditCard>().ReverseMap();
            CreateMap<UserMarkupPlanDto, UserMarkupPlan>().ReverseMap();
            CreateMap<UserPointsRedeemPlanDto, UserPointsRedeemPlan>().ReverseMap();

        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}