using System.Threading.Tasks;
using FluentValidation.Results;
using Core.Domain;
using Core.Mediator.Domain;

namespace Core.Mediator
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected void AdicionarErro(string nomePropriedade, string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(nomePropriedade, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados");

            return ValidationResult;
        }

        protected bool ValidarComando(Command message)
        {
            ValidationResult = new ValidationResult();
            if (message.EhValido()) return true;

            return false;
        }
    }
    public abstract class CommandHandler<TEntity>
    {
        protected ValidationResult<TEntity> ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult<TEntity>();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected void AdicionarErro(string nomePropriedade, string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(nomePropriedade, mensagem));
        }

        protected async Task<ValidationResult<TEntity>> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados");

            return ValidationResult;
        }

        protected bool ValidarComando(Command message)
        {
            ValidationResult = new ValidationResult<TEntity>();
            if (message.EhValido()) return true;

            return false;
        }
    }
}