using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Visita.Domain;
using Core.Mediator;

namespace Visita.Application.Commands
{
    public class VisitaCommandHandler: CommandHandler,
        IRequestHandler<AdicionarVisitaCommand, ValidationResult>
    {
        private readonly IVisitaRepository _visitaRepository;

        public VisitaCommandHandler(IVisitaRepository visitaRepository)
        {
            _visitaRepository = visitaRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarVisitaCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
                return message.ValidationResult;

            if (ValidationResult.Errors.Count > 0)
                return ValidationResult;

            var visita = _visitaRepository.ObterPorId(message.AggregateId);

            if (visita == null)
                _visitaRepository.Adicionar(new Domain.Visita(message.cdcliente, message.cdempresa, message.cdpedido, message.cdsituacaovisita, message.cdvendedor, message.cdvisita,
                    message.deobservacao, message.dtfim, message.dtinicio, message.flexcluido, message.flsituacao, message.AggregateId, message.hrfim, message.hrinicio, message.pedidocliguid,
                    message.timestamp));
            else
            {
                visita.InformarCodigoCliente(message.cdcliente);
                visita.InformarCodigoSituacaoVisita(message.cdsituacaovisita);
                visita.InformarCodigoVendedor((int)message.cdvendedor);
                visita.InformarObservacao(message.deobservacao);
                visita.InformarDataFim(message.dtfim);
                visita.InformarDataInicio(message.dtinicio);
                visita.InformarExcluido(message.flexcluido);
                visita.InformarSituacao(message.flsituacao);
                visita.InformarHoraFim(message.hrfim);
                visita.InformarHoraInicio(message.hrinicio);

                _visitaRepository.Atualizar(visita);
            }
            return await PersistirDados(_visitaRepository.UnitOfWork);
        }
    }
}
