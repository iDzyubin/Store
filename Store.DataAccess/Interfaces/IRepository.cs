using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозитория.
    /// Необходим для осуществления базовых операций с данными.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Добавить элемент
        /// </summary>
        Task InsertAsync( T item );

        /// <summary>
        /// Обновить информацию об элементе
        /// </summary>
        Task UpdateAsync( T item );

        /// <summary>
        /// Удалить элемент
        /// </summary>
        Task DeleteAsync( Guid id );

        /// <summary>
        /// Получить элемент по id
        /// </summary>
        Task<T> GetAsync( Guid id );

        /// <summary>
        /// Получить все элементы
        /// </summary>
        Task<IEnumerable<T>> GetAsync();
    }
}