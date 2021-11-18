using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto item)
        {
            _context.Produtos.Add(item);
        }

        public void Atualizar(Produto item)
        {
            _context.Update(item);
        }

        public async Task<Produto> ObterPorIdAsync(Guid id)
        {
           return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
