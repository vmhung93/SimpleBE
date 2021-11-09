using System.Threading.Tasks;

using SimpleBE.Api.Dtos;

namespace SimpleBE.Api.Services
{
    public interface IAuthService
    {
        AuthDTO SignIn(SignInDTO dto);

        Task SignUp(SignUpDTO dto);
    }
}