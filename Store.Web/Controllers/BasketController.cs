using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Basket;

namespace Store.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController( IBasketService basketService )
        {
            _basketService = basketService;
        }
        
        [HttpGet]
        public IActionResult Index() => View();

        
        [HttpGet]
        public async Task<IActionResult> Add( Guid productId, uint count )
        {
            await _basketService.AddItemAsync( productId, count );
            return RedirectToAction( "Index", "Basket" );
        }

        
        [HttpGet]
        public async Task<IActionResult> Remove( Guid productId )
        {
            await _basketService.RemoveLineAsync( productId );
            return RedirectToAction( "Index", "Basket" );
        }

        
        [HttpGet]
        public async Task<IActionResult> Clear()
        {
            await _basketService.ClearAsync();
            return RedirectToAction( "Index", "Basket" );
        }
    }
}