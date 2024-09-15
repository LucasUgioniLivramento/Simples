using System;
using FluentValidation.Results;
using MediatR;

namespace Core.Mediator.Domain
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Command<TEntity> : Message, IRequest<ValidationResult<TEntity>>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult<TEntity> ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}