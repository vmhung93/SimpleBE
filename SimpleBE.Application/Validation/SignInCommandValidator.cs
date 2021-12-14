using FluentValidation;

using SimpleBE.Application.Commands;

namespace SimpleBE.Application.Validation
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
