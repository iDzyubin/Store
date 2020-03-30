using System;
using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.Product
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        [Display( Name = "Наименование товара" )] 
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}