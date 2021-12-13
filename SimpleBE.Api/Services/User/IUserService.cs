using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleBE.Api.Dtos;

namespace SimpleBE.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> FindAll();

        Task<UserDTO> FindById(Guid id);
    }
}