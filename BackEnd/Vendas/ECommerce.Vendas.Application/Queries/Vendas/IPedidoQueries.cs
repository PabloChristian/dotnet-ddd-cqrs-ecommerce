using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Vendas.Application.Queries.Vendas
{
    public interface IPedidoQueries
    {
        Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
    }
}
