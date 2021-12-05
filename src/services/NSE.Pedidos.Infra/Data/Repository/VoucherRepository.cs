using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Vouchers.Entities;
using NSE.Pedidos.Domain.Vouchers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Pedidos.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async void Adicionar(Voucher item)
        {
            await _context.Vouchers.AddAsync(item);
        }

        public void Atualizar(Voucher item)
        {
            _context.Vouchers.Update(item);
        }

        public async Task<Voucher> ObterPorIdAsync(Guid id)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Voucher>> ObterTodosAsync()
        {
            return await _context.Vouchers.AsNoTracking().ToListAsync();
        }

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(v => v.Codigo == codigo);
        }

        public void Dispose()
            => _context.Dispose();
    }
}
