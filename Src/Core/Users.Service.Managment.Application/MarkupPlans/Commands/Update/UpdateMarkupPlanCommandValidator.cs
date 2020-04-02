using FluentValidation;

namespace Users.Service.Managment.Application.MarkupPlans.Commands.Update
{
    public class UpdateMarkupPlanCommandValidator : AbstractValidator<UpdateMarkupPlanCommand>
    {
        public UpdateMarkupPlanCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.ClientReference).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Markup).NotNull();
            RuleFor(x => x.CanUseCoupon).NotNull();
        }
    }
}