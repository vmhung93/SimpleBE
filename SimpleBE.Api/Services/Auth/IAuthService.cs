using System.Threading.Tasks;

using SimpleBE.Api.Commands;
using SimpleBE.Api.Dtos;

namespace SimpleBE.Api.Services
{
    public interface IAuthService
    {
        Task<AuthDTO> SignIn(SignInCommand command);

        Task SignUp(SignUpCommand command);
    }
}