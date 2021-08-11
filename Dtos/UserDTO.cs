namespace SimpleBE.Dtos
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class CreateUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}