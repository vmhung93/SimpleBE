using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MapsterMapper;
using MediatR;
using BCryptNet = BCrypt.Net.BCrypt;

using SimpleBE.Api.Helpers;
using SimpleBE.Api.Infrastructure;
using SimpleBE.Api.Utils;
using SimpleBE.Api.Entities;
using SimpleBE.Api.Enums;

namespace SimpleBE.Api.Commands
{
    public class SignUpCommand : IRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class SignUpHandler : AsyncRequestHandler<SignUpCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private AppSettings _appSettings;
        private IJwtUtils _jwtUtils;

        public SignUpHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _jwtUtils = jwtUtils;
        }

        protected override async Task Handle(SignUpCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(command);

            user.Role = Role.User;
            user.PasswordHash = BCryptNet.HashPassword(command.Password);

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}