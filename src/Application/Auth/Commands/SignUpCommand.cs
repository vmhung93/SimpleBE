using BCryptNet = BCrypt.Net.BCrypt;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

using SimpleBE.Application.Helpers;
using SimpleBE.Application.Utils;
using SimpleBE.Domain.Enums;
using SimpleBE.Infrastructure.Persistence;
using SimpleBE.Domain.Entities;

namespace SimpleBE.Application.Auth.Commands
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