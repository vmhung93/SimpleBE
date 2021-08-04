using System;

namespace SimpleBE.Dtos
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class CreateUserDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}