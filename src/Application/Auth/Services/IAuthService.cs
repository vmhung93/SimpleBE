using System.Threading.Tasks;

using SimpleBE.Application.Auth.Commands;
using SimpleBE.Application.Auth.Dtos;

namespace SimpleBE.Application.Auth.Services
{
    public interface IAuthService
    {
        Task<AuthDTO> SignIn(SignInCommand command);

        Task SignUp(SignUpCommand command);
    }
}