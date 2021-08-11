using System.Threading.Tasks;

using SimpleBE.Dtos;

namespace SimpleBE.Services
{
    public interface IAuthService
    {
        string SignIn(SignInDTO dto);

        Task SignUp(SignUpDTO dto);
    }
}