using MediatR;

namespace SimpleBE.Api.Services
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