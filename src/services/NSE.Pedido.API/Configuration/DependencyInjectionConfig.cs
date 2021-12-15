﻿using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSE.Core.Mediator;
using NSE.Pedidos.API.Application.Commands;
using NSE.Pedidos.API.Application.Commands.Handlers;
using NSE.Pedidos.API.Application.Events;
using NSE.Pedidos.API.Application.Events.Handlers;
using NSE.Pedidos.API.Application.Queries;
using NSE.Pedidos.API.Application.Queries.Interfaces;
using NSE.Pedidos.Domain.Pedidos.Repository;
using NSE.Pedidos.Domain.Vouchers.Repository;
using NSE.Pedidos.Infra.Data;
using NSE.Pedidos.Infra.Data.Repository;
using NSE.WebAPI.Core.Usuario;

namespace NSE.Pedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            //Commands
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            //Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();
            
            //Data
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<PedidosContext>();

            
            //services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();
        }
    }
}
