using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.DataAccess.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MainDb _db;

        public SaleRepository( MainDb db )
            => _db = db;

        public async Task AcceptAsync( Guid userId )
        {
            if( !_db.SaleItems.Any(x => x.UserId == userId && x.Status == SaleItemStatus.InBasket))
                return;
            
            var transaction = new Transaction
            {
                Id             = Guid.NewGuid(), 
                Status         = TransactionStatus.Accepted, 
                CreateDateTime = DateTime.Now
            };
            await _db.InsertAsync( transaction );

            await _db.SaleItems
                .Where( x =>
                    x.UserId == userId &&
                    x.Status == SaleItemStatus.InBasket
                )
                .Set( x => x.Status, SaleItemStatus.Sold )
                .Set( x => x.TransactionId, transaction.Id )
                .UpdateAsync();
        }

        public async Task CancelAsync( Guid transactionId )
            => await _db.Transactions
                .Where( x => x.Id == transactionId )
                .Set( x => x.Status, TransactionStatus.Canceled )
                .Set( x => x.IsCanceled, true )
                .Set(x => x.CanceledDateTime, DateTime.Now)
                .UpdateAsync();

        public async Task<IEnumerable<SaleItem>> GetSalesItemsAsync( Guid userId )
            => await ( 
                from s in _db.SaleItems
                join p in _db.Products on s.ProductId equals p.Id
                join t in _db.Transactions on s.TransactionId equals t.Id
                where s.Status != SaleItemStatus.InBasket &&
                      s.UserId == userId
                select new SaleItem
                {
                    Id            = s.Id,
                    Count         = s.Count,
                    Status        = s.Status,
                    UserId        = s.UserId,
                    ProductId     = s.ProductId,
                    TransactionId = s.TransactionId,
                    Product       = p,
                    Transaction   = t
                } 
            ).ToListAsync();
    }
}