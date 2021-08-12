using System;
using System.Collections.Generic;
using MapsterMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Threading.Tasks;

using SimpleBE.Dtos;
using SimpleBE.Infrastructure;
using SimpleBE.Entities;

namespace SimpleBE.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> FindAll()
        {
            var users = _unitOfWork.Users.FindAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO FindById(Guid id)
        {
            var user = _unitOfWork.Users.FindById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task Seed()
        {
            _unitOfWork.Users.Add(new User()
            {
                UserName = "admin",
                FirstName = "Michael",
                LastName = "Jackson",
                Role = Enums.Role.Admin,
                PasswordHash = BCryptNet.HashPassword("handsome@2021")
            });

            await _unitOfWork.SaveChangesAsync();
        }
    }
}