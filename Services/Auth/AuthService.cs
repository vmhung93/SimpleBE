
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using SimpleBE.Dtos;
using SimpleBE.Helpers;
using SimpleBE.Models;
using SimpleBE.Utils;

namespace SimpleBE.Services
{
    public class AuthService : IAuthService
    {
        private AppSettings _appSettings;
        private IJwtUtils _jwtUtils;

        public AuthService(IOptions<AppSettings> appSettings, IJwtUtils jwtUtils)
        {
            _appSettings = appSettings.Value;
            _jwtUtils = jwtUtils;
        }

        public async Task<AuthResponseDTO> Authenticate(AuthDTO dto)
        {
            if (dto.UserName == _appSettings.Admin.UserName && dto.Password == _appSettings.Admin.Password)
            {
                var user = new AuthResponseDTO()
                {
                    Id = _appSettings.Admin.Id,
                    UserName = _appSettings.Admin.UserName,
                    FirstName = _appSettings.Admin.FirstName,
                    LastName = _appSettings.Admin.LastName,
                };

                user.JwtToken = _jwtUtils.GenerateToken(new User()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.FirstName,
                });

                return user;
            }

            return null;
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            if (id == _appSettings.Admin.Id)
            {
                var user = new UserDTO()
                {
                    Id = id,
                    FirstName = _appSettings.Admin.FirstName,
                    LastName = _appSettings.Admin.LastName,
                };

                return user;
            }

            return null;
        }
    }
}