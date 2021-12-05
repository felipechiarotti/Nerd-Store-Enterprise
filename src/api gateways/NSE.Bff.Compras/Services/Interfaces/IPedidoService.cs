
using NSE.Bff.Compras.Models.Pedidos;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }
}
