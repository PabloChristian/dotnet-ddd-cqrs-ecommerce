using ECommerce.Catalogo.Domain.Entities.Interfaces;
using ECommerce.Catalogo.Domain.Interface;
using ECommerce.Core.Service.Communication.Interface;
using ECommerce.Core.Service.Message.IntegrationEvent.PedidoEvent;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Catalogo.Domain.Events
{
    public class ProdutoEventHandler :
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>,
        INotificationHandler<PedidoProcessamentoCanceladoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoEventHandler(IProdutoRepository produtoRepository,
                                   IEstoqueService estoqueService,
                                   IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent _mensagem, CancellationToken _cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(_mensagem.AggregateId);

            // Enviar um email para aquisicao de mais produtos.
        }

        public async Task Handle(PedidoIniciadoEvent _message, CancellationToken _cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(_message.ProdutosPedido);

            if (result)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(_message.PedidoId, _message.ClienteId, _message.Total, _message.ProdutosPedido, _message.NomeCartao, _message.NumeroCartao, _message.ExpiracaoCartao, _message.CvvCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(_message.PedidoId, _message.ClienteId));
            }
        }

        public async Task Handle(PedidoProcessamentoCanceladoEvent _message, CancellationToken _cancellationToken)
        {
            await _estoqueService.ReporListaProdutosPedido(_message.ProdutosPedido);
        }
    }
}
