using System;

namespace Store.DataAccess.DataModels
{
    public class Product
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
    }
}