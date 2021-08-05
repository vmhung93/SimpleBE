using System;

namespace SimpleBE.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public AdminUser Admin { get; set; }
    }


    public class AdminUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
