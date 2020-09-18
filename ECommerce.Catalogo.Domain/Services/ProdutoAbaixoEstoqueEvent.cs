using ECommerce.Core.Service.Message.DomainEvent;
using System;

namespace ECommerce.Catalogo.Domain
{
    internal class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        private Guid id;
        private int quantidadeEstoque;

        public ProdutoAbaixoEstoqueEvent(Guid id, int quantidadeEstoque)
        {
            this.id = id;
            this.quantidadeEstoque = quantidadeEstoque;
        }
    }
}