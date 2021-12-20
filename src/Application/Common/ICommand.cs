using MediatR;

namespace SimpleBE.Application.Commands
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}