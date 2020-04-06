using System;

namespace Store.BusinessLogic.Models.Basket
{
    /// <summary>
    /// Данные о товаре в корзине
    /// </summary>
    public class BasketLine
    {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public DataAccess.DataModels.Product Product { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public uint Count { get; set; }
        
        /// <summary>
        /// Общая стоимость
        /// </summary>
        public decimal Total => Product.Price * Count ?? 0;
    }
}