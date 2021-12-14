using MediatR;

namespace SimpleBE.Application.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IMediator _mediator;

        public BaseService(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}