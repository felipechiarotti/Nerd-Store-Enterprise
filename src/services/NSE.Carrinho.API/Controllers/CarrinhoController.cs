using Microsoft.AspNetCore.Mvc;
using NSE.Carrinho.API.Model;
using NSE.WebApi.Core.Controllers;
using NSE.WebAPI.Core.Usuario;
using System.Threading.Tasks;

namespace NSE.Carrinho.API.Controllers
{
    public class CarrinhoController : MainController
    {
        private readonly IAspNetUser _user;

        public CarrinhoController(IAspNetUser user)
        {
            _user = user;
        }

        [HttpGet("carrinho")]
        public async Task<CarrinhoCliente> ObterCarrinho()
        {
            return null;
        }

        [HttpPost("carrinho")]
        public async Task<IActionResult> AdicionarItemCarrinho()
        {
            return CustomResponse();
        }

        [HttpPut("carrinho/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho()
        {
            return CustomResponse();
        }

        [HttpDelete("carrinho")]
        public async Task<IActionResult> AtualizarItemCarrinho()
        {
            return CustomResponse();
        }
    }
}
