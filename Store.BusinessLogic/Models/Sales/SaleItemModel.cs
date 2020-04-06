using System;

namespace Store.BusinessLogic.Models.Sales
{
    /// <summary>
    /// Модель продаваемого товара
    /// для взаимодействия на внешнем уровне
    /// </summary>
    public class SaleItemModel
    {
        /// <summary>
        /// Id товара
        /// </summary>
        public Guid ProductId { get; set; } 
        
        /// <summary>
        /// Количество товара
        /// </summary>
        public uint Count { get; set; } 
        
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}