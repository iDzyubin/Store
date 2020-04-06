using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Sales;
using Store.DataAccess.Interfaces;

namespace Store.BusinessLogic.Services.Sale
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService( ISaleRepository saleRepository )
            => _saleRepository = saleRepository;

        public async Task AcceptAsync( Guid userId )
            => await _saleRepository.AcceptAsync( userId );

        public async Task CancelAsync( Guid transactionId )
            => await _saleRepository.CancelAsync( transactionId );

        public async Task<IEnumerable<TransactionModel>> GetTransactionsAsync( Guid userId )
            => (
                from saleItem in await _saleRepository.GetSalesItemsAsync( userId )
                group saleItem by saleItem.TransactionId
                into g
                select new TransactionModel
                {
                    TransactionId = g.Key ?? Guid.NewGuid(),
                    Status = g.First().Transaction.Status,
                    TotalPrice = g.Sum( x => x.Count * ( x.Product.Price ?? 0 ) )
                }
            ).ToList();
    }
}