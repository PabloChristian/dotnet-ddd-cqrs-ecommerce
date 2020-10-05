using MediatR;
using System;
using FluentValidation.Results;

namespace ECommerce.Core.Service.Message
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
