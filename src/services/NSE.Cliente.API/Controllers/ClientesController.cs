﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Clientes.API.Models;
using NSE.Core.Mediator;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.Identidade;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{

    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(
                new RegistrarClienteCommand(Guid.NewGuid(), "Felipe", "felipechi97@gmail.com", "10575342935")
            );

            return CustomResponse(resultado);
        }

    }
}