using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;
using MapsterMapper;

using SimpleBE.Api.Dtos;
using SimpleBE.Api.Helpers;
using SimpleBE.Api.Entities;
using SimpleBE.Api.Utils;
using SimpleBE.Api.Infrastructure;
using SimpleBE.Api.Enums;

namespace SimpleBE.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private AppSettings _appSettings;
        private IJwtUtils _jwtUtils;

        public AuthService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _jwtUtils = jwtUtils;
        }

        public AuthDTO SignIn(SignInDTO dto)
        {
            var user = _unitOfWork.Users.FindByUserName(dto.UserName);

            if (user == null || !BCryptNet.Verify(dto.Password, user.PasswordHash))
            {
                return null;
            }

            var auth = _mapper.Map<AuthDTO>(user);
            auth.Token = _jwtUtils.GenerateToken(user);

            return auth;
        }

        public async Task SignUp(SignUpDTO dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Role = Role.User;
            user.PasswordHash = BCryptNet.HashPassword(dto.Password);

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}