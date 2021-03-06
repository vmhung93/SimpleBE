using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using SimpleBE.Domain.Enums;

namespace SimpleBE.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
