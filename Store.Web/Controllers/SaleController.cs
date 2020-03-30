using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Sale;

namespace Store.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController( ISaleService saleService )
        {
            _saleService = saleService;
        }

        public async Task<IActionResult> Accept()
        {
            var userId = Guid.NewGuid();
            await _saleService.AcceptAsync( userId );
            return View();
        }

        public async Task<IActionResult> Cancel( Guid transactionId )
        {
            await _saleService.CancelAsync( transactionId );
            return View();
        }
    }
}