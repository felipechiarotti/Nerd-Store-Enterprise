using Dapper;
using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PagedResult<Produto>> ObterPaginadoAsync(int pageSize, int pageIndex, string query = null)
        {
            var sql = $@"SELECT * FROM Produtos
                         WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')
                         ORDER BY [Nome]
                         OFFSET {pageSize * (pageIndex - 1)} ROWS
                         FETCH NEXT {pageSize} ROWS ONLY
                         SELECT COUNT(Id) FROM Produtos
                         Where (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%'";
            var multi = await _context.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = query });

            var produtos = multi.Read<Produto>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedResult<Produto>()
            {
                List = produtos,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query,
                TotalResults = total
            };
        }


        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<List<Produto>> ObterProdutosPorId(string idsProdutos)
        {
            var idsGuid = idsProdutos.Split(',')
                .Select(id => (Ok: Guid.TryParse(id, out var x), Value: x));

            if (!idsGuid.All(nid => nid.Ok)) return new List<Produto>();

            var idsValue = idsGuid.Select(id => id.Value);

            return await _context.Produtos.AsNoTracking()
                .Where(p => idsValue.Contains(p.Id) && p.Ativo).ToListAsync();
        }
    }
}
