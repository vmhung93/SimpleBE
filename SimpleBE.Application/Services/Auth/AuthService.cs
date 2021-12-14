using System.Threading.Tasks;
using MediatR;

using SimpleBE.Application.Dtos;
using SimpleBE.Application.Commands;

namespace SimpleBE.Application.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IMediator mediator) : base(mediator)
        {
        }

        public async Task<AuthDTO> SignIn(SignInCommand command)
        {
            var auth = await _mediator.Send(command);
            return auth;
        }

        public async Task SignUp(SignUpCommand command)
        {
            await _mediator.Send(command);
        }
    }
}