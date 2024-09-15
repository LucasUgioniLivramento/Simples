using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Mediator.Domain
{
    public class ValidationResult<TEntity> : ValidationResult
    {
        public TEntity Result { get; private set; }

        public void AdicionarResultado(TEntity result)
        {
            Result = result;
        }

        public void AdicionarErro(string mensagem)
        {
            Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        public void AdicionarErro(string nomePropriedade, string mensagem)
        {
            Errors.Add(new ValidationFailure(nomePropriedade, mensagem));
        }

        public void AdicionarErros(List<ValidationFailure> validationFailures)
        {
            Errors.AddRange(validationFailures);
        }
    }
}
