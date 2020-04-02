using FluentValidation;

namespace Users.Service.Managment.Application.MarkupPlans.Commands.Create

{
    public class CreateMarkupPlanCommandValidator : AbstractValidator<CreateMarkupPlanCommand> 
    {
        public CreateMarkupPlanCommandValidator()
        {
            RuleFor(x => x.ClientReference).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Markup).NotNull();
            RuleFor(x => x.CanUseCoupon).NotNull();

        }
        
    }

}
