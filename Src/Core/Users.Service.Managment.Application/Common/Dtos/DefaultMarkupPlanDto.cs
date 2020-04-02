using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Users.Service.Managment.Domain.Enums;

namespace Users.Service.Managment.Application.Common.Dtos
{
    public class DefaultMarkupPlanDto
    {
        public int Id { get; set; }
        public int MarkupPlanId { get; set; }
        public ModuleTypes Module { get; set; }
        public  MarkupPlanDto MarkupPlan { get; set; }
    }
}
