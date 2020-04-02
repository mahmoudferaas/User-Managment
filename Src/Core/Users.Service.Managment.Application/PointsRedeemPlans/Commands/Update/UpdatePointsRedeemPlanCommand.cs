using System;
using System.Collections.Generic;
using BaseClasses.Core.Serializations.Api;
using MediatR;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update
{
    public class UpdatePointsRedeemPlanCommand : RequestDetails , IRequest<int> 
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public decimal Balance { get; set; }
        public DateTime PlanDate { get; set; }
        public virtual ICollection<UserPointsRedeemPlan> UserPointsRedeemPlans { get; set; }
        public virtual ICollection<DefaultPointsRedeemPlan> DefaultPointsRedeemPlans { get; set; }

    }
}
