using System;

namespace SimpleBE.Application.Dtos
{
    public class BaseDTO
    {
        public Guid Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}