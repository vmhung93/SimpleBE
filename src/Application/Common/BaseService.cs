using MediatR;

namespace SimpleBE.Application.Common
{
    public interface IBaseService
    {
    }

    public class BaseService : IBaseService
    {
        protected readonly IMediator _mediator;

        public BaseService(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}