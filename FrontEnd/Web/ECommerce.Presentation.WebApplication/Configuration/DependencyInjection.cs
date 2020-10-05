using ECommerce.Catalogo.Application.Interfaces;
using ECommerce.Catalogo.Application.Services;
using ECommerce.Catalogo.Domain;
using ECommerce.Catalogo.Domain.Events;
using ECommerce.Catalogo.Domain.Interface;
using ECommerce.Catalogo.Infrastructure.Context;
using ECommerce.Core.Service.Communication;
using ECommerce.Core.Service.Communication.Interface;
using ECommerce.Core.Service.Message.IntegrationEvent.PedidoEvent;
using ECommerce.Core.Service.Message.Notification;
using ECommerce.Vendas.Application.Commands;
using ECommerce.Vendas.Application.Commands.Vendas;
using ECommerce.Vendas.Application.Events;
using ECommerce.Vendas.Application.Queries.Vendas;
using ECommerce.Vendas.Infrastructure;
using ECommerce.Vendas.Infrastructure.Interfaces;
using ECommerce.Vendas.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Presentation.WebApplication.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            Register_Mediator(services);
            Register_Notifications(services);
            Register_Catalogo(services);
            Register_Vendas(services);
        }

        private static void Register_Mediator(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }

        private static void Register_Notifications(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void Register_Catalogo(IServiceCollection services)
        {
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoProcessamentoCanceladoEvent>, ProdutoEventHandler>();
        }

        private static void Register_Vendas(IServiceCollection services)
        {
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();
            services.AddScoped<VendasContext>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<IniciarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<FinalizarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoEstornarEstoqueCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoEstoqueRejeitadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoPagamentoRealizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoPagamentoRecusadoEvent>, PedidoEventHandler>();
        }
    }
}
