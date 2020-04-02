using System;
using System.Collections.Generic;
using Users.Service.Managment.Domain.Common;

namespace Users.Service.Managment.Domain.Entities
{
    public class PointsRedeemPlan : Entity
    {
        public PointsRedeemPlan()
        {
            UserPointsRedeemPlans = new HashSet<UserPointsRedeemPlan>();
            DefaultPointsRedeemPlans = new HashSet<DefaultPointsRedeemPlan>();
        }

        public int Points { get; set; }

        public decimal Balance { get; set; }

        public DateTime PlanDate { get; set; }

        public virtual ICollection<UserPointsRedeemPlan> UserPointsRedeemPlans { get; set; }

        public virtual ICollection<DefaultPointsRedeemPlan> DefaultPointsRedeemPlans { get; set; }
    }
}
