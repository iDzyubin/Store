using System;

namespace Store.BusinessLogic.Models.Basket
{
    public class BasketLine
    {
        public Guid Id { get; set; }

        public DataAccess.DataModels.Product Product { get; set; }

        public uint Count { get; set; }
        
        public decimal Total => Product.Price * Count;
    }
}