using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Store.BusinessLogic.Models.Product;
using Store.DataAccess.DataModels;

namespace Store.BusinessLogic.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly MainDb _db;

        public ProductService( MainDb db )
            => _db = db;

        public async Task<IEnumerable<ProductModel>> GetProductLines( Guid userId )
            => await (
                from p in _db.Products
                select new ProductModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price ?? 0,
                    IsInBasket = _db.SaleItems.Any( x => x.ProductId == p.Id && x.UserId == userId )
                }
            ).ToListAsync();
    }
}