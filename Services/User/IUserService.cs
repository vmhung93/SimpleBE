using System;
using System.Collections.Generic;

using SimpleBE.Dtos;

namespace SimpleBE.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> FindAll();

        UserDTO FindById(Guid id);
    }
}