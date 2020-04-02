using MediatR;

namespace Users.Service.Managment.Application.MarkupPlans.Commands.Delete
{
    public class DeleteMarkupPlanCommand : IRequest
    {
        public int Id { get; set; }
    }
}