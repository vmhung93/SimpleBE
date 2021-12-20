using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleBE.Application.Users.Dtos;

namespace SimpleBE.Application.Users.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> FindAll();

        Task<UserDTO> FindById(Guid id);
    }
}