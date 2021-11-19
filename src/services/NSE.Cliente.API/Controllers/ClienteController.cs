using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Models;
using NSE.WebApi.Core.Identidade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> Index()
        {
            return await _clienteRepository.ObterTodosAsync();
        }

        [ClaimsAuthorize("Cliente", "Ler")]
        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Cliente> ClienteDetalhe(Guid id)
        {
            return await _clienteRepository.ObterPorIdAsync(id);
        }
    }
}
