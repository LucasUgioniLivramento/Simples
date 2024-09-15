using MediatR;

namespace Core.Mediator.Domain
{
    public abstract class Query<TResponse> : IRequest<TResponse>
    {
        protected Query() { }
    }
}