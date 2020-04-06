using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Basket;
using Store.BusinessLogic.Models.Sales;
using Store.BusinessLogic.Services.Basket;
using Store.Web.Security;

namespace Store.Web.Controllers
{
    /// <summary>
    /// Контроллер корзинки
    /// </summary>
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        /// <summary>
        /// Basic ctor.
        /// </summary>
        public BasketController( IBasketService basketService )
        {
            _basketService = basketService;
        }

        /// <summary>
        /// Отрисовываем страницу с корзинкой
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if( User.GetId() == null && !Request.Cookies.ContainsKey("id"))
            {
                return View( new List<BasketLine>() );
            }
            
            var userId = User.GetId() ?? Guid.Parse( Request.Cookies["id"] );
            var model = await _basketService.GetBasketLinesAsync( userId );
            return View( model );
        }

        /// <summary>
        /// Добавить товар в корзинку
        /// </summary>
        /// <param name="productId">Добавляемый товар</param>
        /// <param name="count">Добавляемое количество (по умолчанию 1)</param>
        [HttpGet]
        public async Task<IActionResult> Add( Guid productId, uint count )
        {
            if( User.GetId() == null && !Request.Cookies.ContainsKey("id"))
            {
                return RedirectToAction("Index", "Product");
            }
            
            var userId = User.GetId() ?? Guid.Parse( Request.Cookies["id"] );
            var model = new SaleItemModel { UserId = userId, Count = count, ProductId = productId };

            await _basketService.AddItemAsync( model );
            return RedirectToAction( "Index", "Product" );
        }

        /// <summary>
        /// Удалить товар из корзинки
        /// </summary>
        /// <param name="productId">Удаляемый товар</param>
        [HttpGet]
        public async Task<IActionResult> Remove( Guid productId )
        {
            var userId = User.GetId() ?? Guid.Parse( Request.Cookies["id"] );
            var model = new SaleItemModel { UserId = userId, ProductId = productId };

            await _basketService.RemoveLineAsync( model );
            return RedirectToAction( "Index", "Basket" );
        }

        /// <summary>
        /// Изменить количество выбранного товара в корзинке
        /// </summary>
        /// <param name="productId">Изменяемый товар</param>
        /// <param name="count">Новое количество</param>
        [HttpGet]
        public async Task<IActionResult> ChangeCount( Guid productId, uint count )
        {
            var userId = User.GetId() ?? Guid.Parse( Request.Cookies["id"] );
            var model = new SaleItemModel { UserId = userId, Count = count, ProductId = productId };

            await _basketService.ChangeCountAsync( model );
            return RedirectToAction( "Index" );
        }

        /// <summary>
        /// Очистить корзинку
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Clear()
        {
            var userId = User.GetId() ?? Guid.Parse( Request.Cookies["id"] );

            await _basketService.ClearAsync( userId );
            return RedirectToAction( "Index", "Basket" );
        }
    }
}