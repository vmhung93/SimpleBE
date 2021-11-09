using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleBE.Api.Dtos;

namespace SimpleBE.Api.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> FindAll();

        UserDTO FindById(Guid id);

        Task Seed();
    }
}