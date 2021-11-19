using NSE.Clientes.API.Models;
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

        public void Adicionar(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
