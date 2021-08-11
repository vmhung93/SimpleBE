using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using SimpleBE.Dtos;
using SimpleBE.Models;
using SimpleBE.Infrastructure;
using MapsterMapper;

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

        public async Task Add(CreateUserDTO dto)
        {
            var user = _mapper.Map<User>(dto);

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}