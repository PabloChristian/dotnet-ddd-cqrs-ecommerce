using ECommerce.Catalogo.Domain.Interface;
using ECommerce.Core.Service.Communication.Interface;
using ECommerce.Core.Service.DomainObject.DTO;
using ECommerce.Core.Service.Message.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public EstoqueService(IProdutoRepository _produtoRepository,
                              IMediatorHandler _mediatorHandler)
        {
            this._produtoRepository = _produtoRepository;
            this._mediatorHandler = _mediatorHandler;
        }

        public async Task<bool> DebitarEstoque(Guid _produtoId, int _quantidade)
        {
            if (!await DebitarItemEstoque(_produtoId, _quantidade)) return false;

            return true;
        }

        public async Task<bool> DebitarListaProdutosPedido(ListaProdutosPedido _lista)
        {
            foreach (var item in _lista.Itens)
            {
                if (!await DebitarItemEstoque(item.Id, item.Quantidade)) return false;
            }

            return true;
        }

        private async Task<bool> DebitarItemEstoque(Guid _produtoId, int _quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(_produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(_quantidade))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("Estoque", $"Produto - {produto.Nome} sem estoque"));
                return false;
            }

            produto.DebitarEstoque(_quantidade);

            //PARAMETRIZAR DEPOIS
            if (produto.QuantidadeEstoque < 10)
            {
                await _mediatorHandler.PublicarDomainEvent(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            return true;
        }

        public async Task<bool> ReporListaProdutosPedido(ListaProdutosPedido lista)
        {
            foreach (var item in lista.Itens)
            {
                await ReporItemEstoque(item.Id, item.Quantidade);
            }

            return true;
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var sucesso = await ReporItemEstoque(produtoId, quantidade);

            if (!sucesso) return false;

            return true;
        }

        private async Task<bool> ReporItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return true;
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
