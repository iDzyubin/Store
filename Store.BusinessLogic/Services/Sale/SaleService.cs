using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Sales;

namespace Store.BusinessLogic.Services.Sale
{
    public class SaleService : ISaleService
    {
        public async Task AcceptAsync( Guid userId )
        {
        }

        public async Task CancelAsync( Guid transactionId )
        {
        }

        public IEnumerable<SaleLine> GetSales()
        {
            return new[]
            {
                new SaleLine { Id = Guid.NewGuid(), Status = SaleStatus.Waiting, TotalPrice = 99.95m },
                new SaleLine { Id = Guid.NewGuid(), Status = SaleStatus.Waiting, TotalPrice = 23.95m },
                new SaleLine { Id = Guid.NewGuid(), Status = SaleStatus.Waiting, TotalPrice = 9.99m },
            };
        }
    }
}