using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Vendas.Domain.Enum
{
    public enum PedidoStatus
    {
        Rascunho = 0,
        Iniciado = 1,
        Pago = 4,
        Entregue = 5,
        Cancelado = 6
    }
}
