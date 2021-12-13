using FluentValidation;
using SimpleBE.Api.Commands;

namespace SimpleBE.Api.Validation
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
