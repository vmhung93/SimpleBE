using System;

namespace SimpleBE.Dtos
{
    public class BaseDTO
    {
        public Guid Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}