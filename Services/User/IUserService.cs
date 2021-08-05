using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleBE.Dtos;

namespace SimpleBE.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDTO>> GetAll();

        public Task<UserDTO> GetById(Guid id);

        public Task<UserDTO> Create(CreateUserDTO dto);
    }
}