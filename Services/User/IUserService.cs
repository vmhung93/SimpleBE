using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleBE.Dtos;

namespace SimpleBE.Services
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> FindAll();

        public UserDTO FindById(Guid id);

        public Task Add(CreateUserDTO dto);
    }
}