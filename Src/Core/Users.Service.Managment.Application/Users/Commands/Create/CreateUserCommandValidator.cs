using FluentValidation;

namespace Users.Service.Managment.Application.Users.Commands.Create

{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> 
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.ClientReference).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty().Matches(@"\A\S+\z"); 
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();

        }
        
    }

}
