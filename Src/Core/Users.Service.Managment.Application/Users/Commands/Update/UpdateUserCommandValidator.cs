using FluentValidation;

namespace Users.Service.Managment.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.ClientReference).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty().Matches(@"\A\S+\z"); ;
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}