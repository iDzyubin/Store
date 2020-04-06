using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Product;

namespace Store.BusinessLogic.Services.Product
{
    /// <summary>
    /// Сервис для работы с товарами.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Вернуть список товаров для конкретного пользователя.
        /// </summary>
        /// <param name="userId">Пользователь</param>
        /// <returns></returns>
        Task<IEnumerable<ProductModel>> GetProductLines( Guid userId );
    }
}