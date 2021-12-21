using BCryptNet = BCrypt.Net.BCrypt;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

using SimpleBE.Application.Helpers;
using SimpleBE.Application.Utils;
using SimpleBE.Application.Commands;
using SimpleBE.Application.Auth.Dtos;
using SimpleBE.Infrastructure.Persistence;

namespace SimpleBE.Application.Auth.Commands
{
    public class SignInCommand : ICommand<AuthDTO>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class SignInHandler : IRequestHandler<SignInCommand, AuthDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private AppSettings _appSettings;
        private IJwtUtils _jwtUtils;

        public SignInHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _jwtUtils = jwtUtils;
        }

        public async Task<AuthDTO> Handle(SignInCommand command, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.Users.FindByUserName(command.UserName);

            if (user == null || !BCryptNet.Verify(command.Password, user.PasswordHash))
            {
                return null;
            }

            var auth = _mapper.Map<AuthDTO>(user);
            auth.Token = _jwtUtils.GenerateToken(user);

            return auth;
        }
    }
}