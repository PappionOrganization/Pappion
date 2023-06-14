using MediatR;

namespace Pappion.Application.Interfaces.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
