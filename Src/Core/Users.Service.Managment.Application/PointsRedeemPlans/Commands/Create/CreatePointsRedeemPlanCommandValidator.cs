using FluentValidation;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Create

{
    public class CreatePointsRedeemPlanCommandValidator : AbstractValidator<CreatePointsRedeemPlanCommand> 
    {
        public CreatePointsRedeemPlanCommandValidator()
        {
            RuleFor(x => x.ClientReference).NotEmpty();
            RuleFor(x => x.Balance).NotNull();
            RuleFor(x => x.Points).NotNull();
            RuleFor(x => x.PlanDate).NotNull();

        }
        
    }

}
