using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Users.Service.Managment.Domain.Enums;

namespace Users.Service.Managment.Application.Common.Dtos
{
    public class DefaultPointsRedeemPlanDto
    {
        public int Id { get; set; }
        public int PointsRedeemPlanId { get; set; }
        public ModuleTypes Module { get; set; }
        public  PointsRedeemPlanDto PointsRedeemPlan { get; set; }
    }
}
