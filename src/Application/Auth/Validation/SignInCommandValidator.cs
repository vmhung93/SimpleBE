using FluentValidation;

using SimpleBE.Application.Auth.Commands;

namespace SimpleBE.Application.Auth.Validation
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
