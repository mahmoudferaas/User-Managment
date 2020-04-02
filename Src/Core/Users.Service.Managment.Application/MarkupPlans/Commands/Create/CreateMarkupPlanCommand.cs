using BaseClasses.Core.Serializations.Api;
using MediatR;
using System;
using System.Collections.Generic;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.MarkupPlans.Commands.Create
{
    public class CreateMarkupPlanCommand : RequestDetails, IRequest<int>
    {
        public string Name { get; set; }
        public decimal Markup { get; set; }
        public bool ApplyPoint { get; set; }
        public bool CanUseCoupon { get; set; }
        public virtual ICollection<UserMarkupPlan> UserMarkupPlans { get; set; }
        public virtual ICollection<DefaultMarkupPlan> DefaultMarkupPlans { get; set; }
    }
}