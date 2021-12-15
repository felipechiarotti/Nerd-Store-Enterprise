
using NSE.Bff.Compras.Models.Pedidos;
using NSE.Core.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<ResponseResult> FinalizarPedido(PedidoDTO pedido);
        Task<PedidoDTO> ObterUltimoPedido();
        Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId();

        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }
}
