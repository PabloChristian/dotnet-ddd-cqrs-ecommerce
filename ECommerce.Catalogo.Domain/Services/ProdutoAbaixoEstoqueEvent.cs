using System;

namespace ECommerce.Catalogo.Domain
{
    internal class ProdutoAbaixoEstoqueEvent
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