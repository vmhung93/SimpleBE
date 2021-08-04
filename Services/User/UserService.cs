using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using SimpleBE.Dtos;
using SimpleBE.Models;
using SimpleBE.Helpers;

namespace SimpleBE.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = FileHelper.DeserializeUsersFromFile();
            return users;
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var users = FileHelper.DeserializeUsersFromFile();

            if (users == null)
            {
                return null;
            }

            return users.Find(u => u.Id == id);
        }

        public async Task<UserDTO> Create(CreateUserDTO dto)
        {
            var user = new UserDTO()
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            FileHelper.SerializeUsersToFile(user);

            return user;
        }

        private static UserDTO UserToDTO(User user) =>
            new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
    }
}