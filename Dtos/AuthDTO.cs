using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBE.Dtos
{
    public class AuthDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AuthResponseDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string JwtToken { get; set; }
    }
}