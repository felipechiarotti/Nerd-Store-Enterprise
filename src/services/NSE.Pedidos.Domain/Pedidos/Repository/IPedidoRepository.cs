using NSE.Core.Data;
using NSE.Pedidos.Domain.Pedidos.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Pedidos.Domain.Pedidos.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId);

        Task<PedidoItem> ObterItemPorId(Guid id);
        Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
    }
}
