using NSE.Bff.Compras.Models.Carrinho;
using NSE.Bff.Compras.Models.Pedidos;
using NSE.Core.Communication;
using System;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface ICarrinhoService
    {
        Task<CarrinhoDTO> ObterCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto);
        Task<ResponseResult> AtualizarItemCarrinhho(Guid produtoId, ItemCarrinhoDTO carrinho);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResult> AplicarVoucherCarrinho(VoucherDTO voucher);

    }
}
