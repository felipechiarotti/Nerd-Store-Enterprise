using NSE.Bff.Compras.Models.Pedidos;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface IClienteService
    {

            Task<EnderecoDTO> ObterEndereco();

    }
}
