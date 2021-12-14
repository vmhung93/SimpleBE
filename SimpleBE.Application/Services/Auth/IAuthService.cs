using System.Threading.Tasks;

using SimpleBE.Application.Commands;
using SimpleBE.Application.Dtos;

namespace SimpleBE.Application.Services
{
    public interface IAuthService
    {
        Task<AuthDTO> SignIn(SignInCommand command);

        Task SignUp(SignUpCommand command);
    }
}