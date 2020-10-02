using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Service.Message.DomainEvent
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
    }
}
