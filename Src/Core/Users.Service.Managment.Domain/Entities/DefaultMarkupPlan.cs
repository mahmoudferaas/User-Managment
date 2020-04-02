
using Users.Service.Managment.Domain.Common;
using Users.Service.Managment.Domain.Enums;

namespace Users.Service.Managment.Domain.Entities
{
    public class DefaultMarkupPlan : Entity
    {
        public int MarkupPlanId { get; set; }
        public ModuleTypes Module { get; set; }
        public virtual MarkupPlan MarkupPlan { get; set; }
    }
}
