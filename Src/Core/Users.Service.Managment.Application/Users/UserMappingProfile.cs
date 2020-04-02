using AutoMapper;
using System;
using Users.Service.Managment.Application.Common.Dtos;
using Users.Service.Managment.Application.Users.Commands.Create;
using Users.Service.Managment.Application.Users.Commands.Update;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Users.Commands
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>().ForMember(m => m.ParentUserId, action => action.Condition(c => c.ParentUserId != Guid.Empty));
            CreateMap<User, CreateUserCommand>();

            CreateMap<UpdateUserCommand, User>().ForMember(m => m.ParentUserId, action => action.Condition(c => c.ParentUserId != Guid.Empty));
            CreateMap<User, UpdateUserCommand>();

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreditCardDto, UserCreditCard>().ReverseMap(); 
            CreateMap<UserMarkupPlanDto, UserMarkupPlan>().ReverseMap(); 
            CreateMap<UserPointsRedeemPlanDto, UserPointsRedeemPlan>().ReverseMap(); 
        }
    }
}