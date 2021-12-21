using MapsterMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

using SimpleBE.Application.Users.Dtos;
using SimpleBE.Infrastructure.Persistence;

namespace SimpleBE.Api.User.Queries
{
    public class FindUserByIdQuery : IRequest<UserDTO>
    {
        public Guid Id { get; set; }
    }

    public class FindUserByIdHandler : IRequestHandler<FindUserByIdQuery, UserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.Users.FindById(request.Id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}