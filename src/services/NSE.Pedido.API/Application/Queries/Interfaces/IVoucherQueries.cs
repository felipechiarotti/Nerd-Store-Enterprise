
using NSE.Pedidos.API.Application.DTO;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Queries.Interfaces
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }
}
