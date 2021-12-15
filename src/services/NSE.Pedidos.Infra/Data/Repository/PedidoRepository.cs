using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Pedidos.Entities;
using NSE.Pedidos.Domain.Pedidos.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Pedidos.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;

        public PedidoRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<PedidoItem> ObterItemPorId(Guid id) =>
            await _context.PedidoItems.FindAsync(id);

        public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId) =>
            await _context.PedidoItems.FirstOrDefaultAsync(p => p.PedidoId == pedidoId && p.ProdutoId == produtoId);

        public async Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId) =>
            await _context.Pedidos
            .Include(p => p.PedidoItems)
            .AsNoTracking()
            .Where(p => p.ClienteId == clienteId)
            .ToListAsync();

        public async Task<Pedido> ObterPorIdAsync(Guid id) =>
            await _context.Pedidos.FindAsync(id);

        public async Task<IEnumerable<Pedido>> ObterTodosAsync() =>
            await _context.Pedidos.AsNoTracking().ToListAsync();

        public void Adicionar(Pedido item) =>
            _context.Pedidos.Add(item);

        public void Atualizar(Pedido item) =>
            _context.Pedidos.Update(item);

        public void Dispose() => _context.Dispose();

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();
    }
}
