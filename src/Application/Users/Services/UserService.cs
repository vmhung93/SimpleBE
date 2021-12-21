using System;
using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;

using SimpleBE.Application.Common;
using SimpleBE.Application.Users.Dtos;
using SimpleBE.Api.User.Queries;

namespace SimpleBE.Application.Users.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IEnumerable<UserDTO>> FindAll()
        {
            var users = await _mediator.Send(new FindUsersQuery());
            return users;
        }

        public async Task<UserDTO> FindById(Guid id)
        {
            var user = await _mediator.Send(new FindUserByIdQuery { Id = id });
            return user;
        }
    }
}