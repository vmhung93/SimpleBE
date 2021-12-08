using System;

namespace SimpleBE.Api.Dtos
{
    public class BaseDTO
    {
        public Guid Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}