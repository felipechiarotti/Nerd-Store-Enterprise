using Microsoft.EntityFrameworkCore;
using NSE.Clientes.API.Models;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;

        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Cliente item)
            => _context.Clientes.Add(item);

        public void Atualizar(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
            => _context.Dispose();

        public async Task<Cliente> ObterPorCpf(string cpf)
            => await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);

        public async Task<Cliente> ObterPorIdAsync(Guid id)
            => await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
            => await _context.Clientes.AsNoTracking().ToListAsync();

    }
}
