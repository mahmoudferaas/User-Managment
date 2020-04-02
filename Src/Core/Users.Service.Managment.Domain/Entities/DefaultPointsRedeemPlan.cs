
using Users.Service.Managment.Domain.Common;
using Users.Service.Managment.Domain.Enums;

namespace Users.Service.Managment.Domain.Entities
{
    public class DefaultPointsRedeemPlan : Entity
    {
        public int PointsRedeemPlanId { get; set; }
        public ModuleTypes Module { get; set; }
        public virtual PointsRedeemPlan PointsRedeemPlan { get; set; }
    }
}
