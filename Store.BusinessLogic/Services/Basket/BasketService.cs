using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.BusinessLogic.Models.Basket;
using Store.BusinessLogic.Models.Sales;
using Store.BusinessLogic.Services.Account;
using Store.DataAccess.DataModels;
using Store.DataAccess.Interfaces;

namespace Store.BusinessLogic.Services.Basket
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public BasketService
        ( 
            IBasketRepository basketRepository, 
            IAccountService accountService, 
            IMapper mapper 
        )
        {
            _basketRepository = basketRepository;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task AddItemAsync( SaleItemModel model )
        {
            var saleItem = _mapper.Map<SaleItem>( model );

            var isUserExists = await _accountService.GetUserAsync( saleItem.UserId ) != null;
            if( !isUserExists )
            {
                await _accountService.CreateTemporaryAccountAsync( saleItem.UserId );
            }

            var isSaleItemExists = await _basketRepository.GetAsync( saleItem.UserId, saleItem.ProductId ) != null;
            if( isSaleItemExists )
            {
                return;
            }

            await _basketRepository.InsertAsync( saleItem );
        }

        public async Task ChangeCountAsync( SaleItemModel model )
        {
            var saleItem = _mapper.Map<SaleItem>( model );
            
            var isUserExists = await _accountService.GetUserAsync( saleItem.UserId ) != null;
            if( !isUserExists )
            {
                return;
            }
            
            var item = await _basketRepository.GetAsync( saleItem.UserId, saleItem.ProductId );
            if( item == null )
            {
                return;
            }

            saleItem.Id = item.Id;
            await _basketRepository.UpdateAsync( saleItem );
        }

        public async Task RemoveLineAsync( SaleItemModel model )
        {
            var saleItem = _mapper.Map<SaleItem>( model );
            
            var isUserExists = await _accountService.GetUserAsync( saleItem.UserId ) != null;
            if( !isUserExists )
            {
                return;
            }
            
            var isSaleItemExists = await _basketRepository.GetAsync( saleItem.UserId, saleItem.ProductId ) != null;
            if( !isSaleItemExists )
            {
                return;
            }

            await _basketRepository.DeleteAsync( saleItem.UserId, saleItem.ProductId );
        }

        public async Task ClearAsync( Guid userId )
            => await _basketRepository.DeleteByUserAsync( userId );

        public async Task<IEnumerable<BasketLine>> GetBasketLinesAsync( Guid userId )
        {
            var saleLines = await _basketRepository.GetAllSaleItemsAsync( userId );
            var basketLines = _mapper.Map<IEnumerable<BasketLine>>( saleLines );
            return basketLines;
        }
    }
}