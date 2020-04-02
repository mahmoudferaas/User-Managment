using System.Collections.Generic;
using Users.Service.Managment.Domain.Common;

namespace Users.Service.Managment.Domain.Entities
{
    public class MarkupPlan : Entity
    {
        public MarkupPlan()
        {
            UserMarkupPlans = new HashSet<UserMarkupPlan>();
            DefaultMarkupPlans = new HashSet<DefaultMarkupPlan>();
        }
        public string Name { get; set; }

        public decimal Markup { get; set; }

        public bool ApplyPoint { get; set; }

        public bool CanUseCoupon { get; set; }

        public virtual ICollection<UserMarkupPlan> UserMarkupPlans { get; set; }

        public virtual ICollection<DefaultMarkupPlan> DefaultMarkupPlans { get; set; }
    }
}
