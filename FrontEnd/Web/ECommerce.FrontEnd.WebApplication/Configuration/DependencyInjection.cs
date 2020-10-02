using ECommerce.Catalogo.Application.Interfaces;
using ECommerce.Catalogo.Application.Services;
using ECommerce.Catalogo.Domain;
using ECommerce.Catalogo.Domain.Events;
using ECommerce.Catalogo.Domain.Interface;
using ECommerce.Catalogo.Domain.Interfaces;
using ECommerce.Catalogo.Infrastructure.Context;
using ECommerce.Catalogo.Infrastructure.Repository;
using ECommerce.Core.Service.Communication;
using ECommerce.Core.Service.Communication.Interface;
using ECommerce.Core.Service.Message.IntegrationEvent.PedidoEvent;
using ECommerce.Core.Service.Message.Notification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.FrontEnd.WebApplication.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoProcessamentoCanceladoEvent>, ProdutoEventHandler>();
        }
    }
}
