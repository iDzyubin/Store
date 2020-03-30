using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync( T item );

        Task UpdateAsync( T item );

        Task DeleteAsync( Guid id );

        Task<T> GetAsync( Guid id );

        Task<IEnumerable<T>> GetAsync();
    }
}