using FluentValidation;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update
{
    public class UpdatePointsRedeemPlanCommandValidator : AbstractValidator<UpdatePointsRedeemPlanCommand>
    {
        public UpdatePointsRedeemPlanCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.ClientReference).NotEmpty();
            RuleFor(x => x.Balance).NotNull();
            RuleFor(x => x.Points).NotNull();
            RuleFor(x => x.PlanDate).NotNull();
        }
    }
}