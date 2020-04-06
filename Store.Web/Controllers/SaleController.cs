using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Account;
using Store.BusinessLogic.Services.Sale;
using Store.DataAccess.DataModels;
using Store.Web.Security;

namespace Store.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с продажами
    /// </summary>
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IAccountService _accountService;

        /// <summary>
        /// Basic ctor
        /// </summary>
        /// <param name="saleService"></param>
        /// <param name="accountService"></param>
        public SaleController( ISaleService saleService, IAccountService accountService )
        {
            _saleService = saleService;
            _accountService = accountService;
        }

        // TODO. Также, по возможности, добавить span для количества товаров в корзине.
        /// <summary>
        /// Подтвердить продажу товара
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Accept()
        {
            var userId = User.GetId();
            if( userId == null )
            {
                return RedirectToAction( "SignIn", "Account" );
            }
            
            await _saleService.AcceptAsync( userId.Value );
            return View();
        }

        /// <summary>
        /// Отмена продажи товара
        /// </summary>
        /// <param name="transactionId">Номер отменяемой транзакции</param>
        [HttpGet]
        public async Task<IActionResult> Cancel( Guid transactionId )
        {
            await _saleService.CancelAsync( transactionId );
            return View();
        }
    }
}