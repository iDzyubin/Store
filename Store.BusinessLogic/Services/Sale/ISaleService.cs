using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Sales;

namespace Store.BusinessLogic.Services.Sale
{
    public interface ISaleService
    {
        Task AcceptAsync( Guid userId );

        Task CancelAsync( Guid transactionId );

        IEnumerable<SaleLine> GetSales();
    }
}