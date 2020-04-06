using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.DataAccess.DataModels;

namespace Store.DataAccess.Interfaces
{
    public interface IBasketRepository : IRepository<SaleItem>
    {
        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="userId">Пользователь</param>
        /// <param name="productId">Удаляемый продукт</param>
        Task DeleteAsync( Guid userId, Guid productId );

        /// <summary>
        /// Удалить все элементы корзины пользователя
        /// </summary>
        /// <param name="userId">Пользователь, чья корзина чистится</param>
        Task DeleteByUserAsync( Guid userId );

        /// <summary>
        /// Получить строчку корзины с определенным товаром
        /// </summary>
        /// <param name="userId">Владелец корзины</param>
        /// <param name="productId">Товар</param>
        Task<SaleItem> GetAsync( Guid userId, Guid productId );
        
        /// <summary>
        /// Получить все элементы корзины
        /// </summary>
        /// <param name="userId">Владелец корзины</param>
        Task<IEnumerable<SaleItem>> GetAllSaleItemsAsync( Guid userId );
    }
}