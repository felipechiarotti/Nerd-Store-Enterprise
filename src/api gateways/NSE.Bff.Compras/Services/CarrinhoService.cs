using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Extensions;
using NSE.Bff.Compras.Models.Carrinho;
using NSE.Bff.Compras.Models.Pedidos;
using NSE.Bff.Compras.Services.Interfaces;
using NSE.Core.Communication;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services
{
    public class CarrinhoService : Service, ICarrinhoService
    {

        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServiceSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }

        public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto)
        {
            var itemContent = ObterConteudo(produto);

            var response = await _httpClient.PostAsync("/carrinho/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AtualizarItemCarrinhho(Guid produtoId, ItemCarrinhoDTO carrinho)
        {
            var itemContent = ObterConteudo(carrinho);

            var response = await _httpClient.PutAsync($"/carrinho/{carrinho.ProdutoId}", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<CarrinhoDTO> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoDTO>(response);
        }

        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AplicarVoucherCarrinho(VoucherDTO voucher)
        {
            var itemContent = ObterConteudo(voucher);

            var response = await _httpClient.PostAsync("/carrinho/aplicar-voucher/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }
    }
}
