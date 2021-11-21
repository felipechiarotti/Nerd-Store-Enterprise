using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(Guid id);
        void Adicionar(T item);
        void Atualizar(T item);
    }
}
