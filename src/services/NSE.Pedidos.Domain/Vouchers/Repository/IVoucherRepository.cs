using NSE.Core.Data;
using NSE.Pedidos.Domain.Vouchers.Entities;
using System.Threading.Tasks;

namespace NSE.Pedidos.Domain.Vouchers.Repository
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> ObterVoucherPorCodigo(string codigo);
    }
}
