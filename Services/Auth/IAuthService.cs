using System;
using System.Threading.Tasks;

using SimpleBE.Dtos;

namespace SimpleBE.Services
{
    public interface IAuthService
    {
        public Task<AuthResponseDTO> Authenticate(AuthDTO dto);

        public Task<UserDTO> GetById(Guid id);
    }
}