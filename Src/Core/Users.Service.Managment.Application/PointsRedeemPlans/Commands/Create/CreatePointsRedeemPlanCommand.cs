using BaseClasses.Core.Serializations.Api;
using MediatR;
using System;
using System.Collections.Generic;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create
{
    public class CreatePointsRedeemPlanCommand : RequestDetails, IRequest<int>
    {
        public int Points { get; set; }
        public decimal Balance { get; set; }
        public DateTime PlanDate { get; set; }
        public virtual ICollection<UserPointsRedeemPlan> UserPointsRedeemPlans { get; set; }
        public virtual ICollection<DefaultPointsRedeemPlan> DefaultPointsRedeemPlans { get; set; }
    }
}