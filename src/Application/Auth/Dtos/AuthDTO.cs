using SimpleBE.Application.Users.Dtos;

namespace SimpleBE.Application.Auth.Dtos
{
    public class AuthDTO : UserDTO
    {
        public string Token { get; set; }
    }
}