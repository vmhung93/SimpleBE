using System.ComponentModel.DataAnnotations;

namespace SimpleBE.Api.Dtos
{
    public class AuthDTO : UserDTO
    {
        public string Token { get; set; }
    }

    public class SignInDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class SignUpDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}