using SimpleBE.Application.Dtos;
using SimpleBE.Domain.Enums;

namespace SimpleBE.Application.Users.Dtos
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public Role Role { get; set; }
    }
}