using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

using SimpleBE.Domain.Entities;

namespace SimpleBE.Infrastructure
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("b43b9241-8254-4b60-bdd3-718c66482add"),
                    UserName = "admin",
                    FirstName = "Simple",
                    LastName = "BE",
                    Role = Domain.Enums.Role.Admin,
                    PasswordHash = BCryptNet.HashPassword("admin")
                }
            );
        }
    }
}