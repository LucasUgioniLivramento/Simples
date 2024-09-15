using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Core.Mediator.DomainEvents;
using Core.Mediator.Notifications;
using Core.Mediator.Domain;

namespace Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviarComando<TRequest>(TRequest comando) where TRequest : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task<TResponse> EnviarConsulta<TRequest,TResponse>(TRequest consulta) where TRequest : Query<TResponse>
        {
            return await _mediator.Send(consulta);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }

        public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
        {
            await _mediator.Publish(notificacao);
        }
    }
}
