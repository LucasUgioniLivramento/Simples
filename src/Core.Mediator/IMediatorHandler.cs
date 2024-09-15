using System.Threading.Tasks;
using FluentValidation.Results;
using Core.Mediator.Domain;
using Core.Mediator.DomainEvents;
using Core.Mediator.Notifications;

namespace Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;

        Task<ValidationResult> EnviarComando<TRequest>(TRequest comando) where TRequest : Command;
        Task<TResponse> EnviarConsulta<TRequest,TResponse>(TRequest consulta) where TRequest : Query<TResponse> ;
    }
}
