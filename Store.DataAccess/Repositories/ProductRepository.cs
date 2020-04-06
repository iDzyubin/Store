using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqToDB;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainDb _db;

        public ProductRepository( MainDb db )
            => _db = db;

        public async Task InsertAsync( Product item )
        {
            item.Id = Guid.NewGuid();
            await _db.InsertAsync( item );
        }

        public async Task UpdateAsync( Product item )
            => await _db.UpdateAsync( item );

        public async Task DeleteAsync( Guid id )
            => await _db.Products.DeleteAsync( x => x.Id == id );

        public async Task<Product> GetAsync( Guid id )
            => await _db.Products.FirstOrDefaultAsync( x => x.Id == id );

        public async Task<IEnumerable<Product>> GetAsync()
            => await _db.Products.ToListAsync();
    }
}