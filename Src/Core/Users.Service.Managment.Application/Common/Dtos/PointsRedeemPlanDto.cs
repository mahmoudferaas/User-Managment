using System;
using System.Collections.Generic;
using Users.Service.Managment.Domain.Enums;

namespace Users.Service.Managment.Application.Common.Dtos
{
    public class PointsRedeemPlanDto
    {
        public long Id { get; set; }
        public ModuleTypes Module { get; set; }
        public int PointsRedeemPlanId { get; set; }
        public int Points { get; set; }
        public decimal Balance { get; set; }
        public DateTime PlanDate { get; set; }
        public List<UserPointsRedeemPlanDto> UserPointsRedeemPlans { get; set; }
        public List<DefaultPointsRedeemPlanDto> DefaultPointsRedeemPlans { get; set; }
    }
}