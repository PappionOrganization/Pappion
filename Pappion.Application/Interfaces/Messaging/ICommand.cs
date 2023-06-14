using MediatR;

namespace Pappion.Application.Interfaces.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
