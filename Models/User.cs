using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBE.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
