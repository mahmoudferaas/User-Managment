using System;
using Users.Service.Managment.Domain.Enums;

namespace Users.Service.Managment.Application.Common.Dtos
{
    public class UserMarkupPlanDto
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public int MarkupPlanId { get; set; }
        public ModuleTypes Module { get; set; }
        public  UserDto User { get; set; }
        public  MarkupPlanDto MarkupPlan { get; set; }
    }
}