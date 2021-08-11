using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;
using MapsterMapper;

using SimpleBE.Dtos;
using SimpleBE.Helpers;
using SimpleBE.Entities;
using SimpleBE.Utils;
using SimpleBE.Infrastructure;
using SimpleBE.Enums;

namespace SimpleBE.Services
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

        public string SignIn(SignInDTO dto)
        {
            var user = _unitOfWork.Users.FindByUserName(dto.UserName);

            if (user == null || !BCryptNet.Verify(dto.Password, user.PasswordHash))
            {
                return null;
            }

            return _jwtUtils.GenerateToken(user);
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