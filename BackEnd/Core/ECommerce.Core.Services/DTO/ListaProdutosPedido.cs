using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Service.DomainObject.DTO
{
    public class ListaProdutosPedido
    {
        public Guid PedidoId { get; set; }
        public ICollection<Item> Itens { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
    }
}
