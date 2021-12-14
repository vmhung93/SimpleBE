using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleBE.Application.Dtos;

namespace SimpleBE.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> FindAll();

        Task<UserDTO> FindById(Guid id);
    }
}