using System;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.Product
{
    /// <summary>
    /// Информация о товаре
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Display( Name = "Наименование товара" )] 
        public string Title { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Лежит ли элемент в корзине
        /// </summary>
        public bool IsInBasket { get; set; }
    }
}