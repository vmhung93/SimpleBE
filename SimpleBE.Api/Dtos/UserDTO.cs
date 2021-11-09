using SimpleBE.Api.Enums;

namespace SimpleBE.Api.Dtos
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public Role Role { get; set; }
    }
}