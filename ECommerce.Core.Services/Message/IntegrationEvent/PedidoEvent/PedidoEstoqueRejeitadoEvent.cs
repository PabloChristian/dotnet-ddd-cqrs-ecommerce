using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Service.Message.IntegrationEvent.PedidoEvent
{
    public class PedidoEstoqueRejeitadoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }

        public PedidoEstoqueRejeitadoEvent(Guid pedidoId, Guid clienteId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}
