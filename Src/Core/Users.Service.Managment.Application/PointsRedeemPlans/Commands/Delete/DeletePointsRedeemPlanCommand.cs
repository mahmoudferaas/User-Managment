using MediatR;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Delete
{
    public class DeletePointsRedeemPlanCommand : IRequest
    {
        public int Id { get; set; }
    }
}