using NSE.Bff.Compras.Models.Catalogo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services.Interfaces
{
    public interface ICatalogoService
    {
        Task<ItemProdutoDTO> ObterPorId(Guid id);
        Task<IEnumerable<ItemProdutoDTO>> ObterItens(IEnumerable<Guid> ids);
    }
}
