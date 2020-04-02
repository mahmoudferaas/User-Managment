using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Users.Service.Managment.Application.Common.Dtos
{
    public class MarkupPlanDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Markup { get; set; }
        public bool ApplyPoint { get; set; }
        public bool CanUseCoupon { get; set; }
        public List<UserMarkupPlanDto> UserMarkupPlans { get; set; }
        public List<DefaultMarkupPlanDto> DefaultMarkupPlans { get; set; }
    }
}
