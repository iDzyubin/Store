using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Basket;
using Store.DataAccess.Interfaces;

namespace Store.BusinessLogic.Services.Basket
{
    // TODO.
    public class BasketService : IBasketService
    {
        private readonly IProductRepository _productRepository;
        private List<BasketLine> BasketLines = new List<BasketLine>();

        public BasketService( IProductRepository productRepository )
        {
            _productRepository = productRepository;

            foreach( var product in _productRepository.GetAsync().Result )
            {
                BasketLines.Add( new BasketLine { Id = Guid.NewGuid(), Product = product, Count = 1} );
            }
        }

        public async Task AddItemAsync( Guid productId, uint count )
        {
            var line = BasketLines.FirstOrDefault( x => x.Id == productId );
            if( line == null ) return;

            BasketLines.Remove( line );

            line.Count = count;
            BasketLines.Add( line );
        }

        public async Task RemoveLineAsync( Guid productId )
        {
            var line = BasketLines.FirstOrDefault( x => x.Id == productId );
            if( line == null ) return;

            BasketLines.Remove( line );
        }

        public Task ClearAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLinesAsync()
        {
            return BasketLines;
        }
    }
}