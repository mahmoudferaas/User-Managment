
using System;
using Users.Service.Managment.Domain.Common;
using Users.Service.Managment.Domain.Enums;

namespace Users.Service.Managment.Domain.Entities
{
    public class UserPointsRedeemPlan : Entity<long>
    {
        public Guid UserId { get; set; }

        public int PointsRedeemPlanId { get; set; }

        public ModuleTypes Module { get; set; }

        public virtual User User { get; set; }

        public virtual PointsRedeemPlan PointsRedeemPlan { get; set; }
    }
}
