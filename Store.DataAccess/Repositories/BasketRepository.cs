using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly MainDb _db;

        public BasketRepository( MainDb db )
            => _db = db;
        
        public async Task InsertAsync( SaleItem item )
        {
            item.Id = Guid.NewGuid();
            await _db.InsertAsync( item );
        }

        public async Task UpdateAsync( SaleItem item )
            => await _db.UpdateAsync( item );

        public async Task DeleteAsync( Guid id )
            => await _db.SaleItems.DeleteAsync( x => x.Id == id );

        public async Task DeleteAsync( Guid userId, Guid productId )
            => await _db.SaleItems.DeleteAsync( x => x.UserId == userId && x.ProductId == productId );

        public async Task DeleteByUserAsync( Guid userId )
            => await _db.SaleItems.DeleteAsync( x => x.UserId == userId );
        
        public async Task<SaleItem> GetAsync( Guid id )
            => await _db.SaleItems.FirstOrDefaultAsync( x => x.Id == id );

        public async Task<SaleItem> GetAsync( Guid userId, Guid productId )
            => await (
                from s in _db.SaleItems
                where s.UserId    == userId    &&
                      s.ProductId == productId &&
                      s.Status    == SaleItemStatus.InBasket
                select s
            ).FirstOrDefaultAsync();

        public async Task<IEnumerable<SaleItem>> GetAllSaleItemsAsync( Guid userId )
            => await ( 
                from s in _db.SaleItems
                join p in _db.Products on s.ProductId equals p.Id
                where s.UserId == userId && 
                      s.Status == SaleItemStatus.InBasket
                select new SaleItem
                {
                    Id = s.Id, 
                    Count = s.Count,
                    Product = p
                } 
            ).ToListAsync();

        public Task<IEnumerable<SaleItem>> GetAsync()
            => throw new NotImplementedException();
    }
}