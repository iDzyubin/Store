using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repositories
{
    // TODO.
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> Products = new List<Product>
        {
            new Product { Id = Guid.NewGuid(), Title = "Fruits",     Description = "", Price = 19.99m },
            new Product { Id = Guid.NewGuid(), Title = "Vegetables", Description = "", Price = 9.99m },
            new Product { Id = Guid.NewGuid(), Title = "Chocolates", Description = "", Price = 29.99m },
        };

        public Task InsertAsync( Product item )
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync( Product item )
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync( Guid id )
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync( Guid id )
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return Products;
        }
    }
}