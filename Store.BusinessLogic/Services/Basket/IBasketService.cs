using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Basket;
using Store.BusinessLogic.Models.Sales;

namespace Store.BusinessLogic.Services.Basket
{
    /// <summary>
    /// Интерфейс сервиса для работы с корзиной
    /// </summary>
    public interface IBasketService
    {
        /// <summary>
        /// Добавить элемент в корзину пользователя.
        /// </summary>
        /// <param name="model">Данные о добавляемом товаре</param>
        Task AddItemAsync( SaleItemModel model );

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="model">Данные об удаляемом товаре</param>
        Task RemoveLineAsync( SaleItemModel model );

        /// <summary>
        /// Очистить корзину от всех товаров
        /// </summary>
        /// <param name="userId">Пользователь, чья корзина чистится</param>
        Task ClearAsync( Guid userId );
        
        /// <summary>
        /// Получить все товары, которые находятся в корзине
        /// </summary>
        /// <param name="userId">Пользователь, чьи товары берутся</param>
        /// <returns>Товары в корзине пользователя</returns>
        Task<IEnumerable<BasketLine>> GetBasketLinesAsync( Guid userId );

        /// <summary>
        /// Изменить количество определенного товара в корзине
        /// </summary>
        /// <param name="model">Данные об изменяемом товаре</param>
        Task ChangeCountAsync( SaleItemModel model );
    }
}