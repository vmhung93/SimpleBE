using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;

using SimpleBE.Application.Dtos;
using SimpleBE.Infrastructure;

namespace SimpleBE.Api.Queries
{
    public class FindUsersQuery : IRequest<IEnumerable<UserDTO>> { }

    public class FindUsersHandler : IRequestHandler<FindUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Handle(FindUsersQuery request, CancellationToken cancellationToken)
        {

            var users = _unitOfWork.Users.FindAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}