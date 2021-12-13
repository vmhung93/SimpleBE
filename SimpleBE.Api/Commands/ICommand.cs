
using MediatR;

namespace SimpleBE.Api.Commands
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}