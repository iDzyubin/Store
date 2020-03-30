using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Basket;

namespace Store.BusinessLogic.Services.Basket
{
    public interface IBasketService
    {
        Task AddItemAsync( Guid productId, uint count );

        Task RemoveLineAsync( Guid productId );

        Task ClearAsync();

        Task<IEnumerable<BasketLine>> GetBasketLinesAsync();
    }
}