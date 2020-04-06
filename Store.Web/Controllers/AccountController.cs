using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Account;
using Store.BusinessLogic.Models.Product;
using Store.BusinessLogic.Services.Account;
using Store.Web.Extensions;
using Store.Web.Security;

namespace Store.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтом.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        /// <summary>
        /// Basic ctor.
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController( IAccountService accountService )
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Отрисовываем страницу регистрации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SignUp() => View();

        /// <summary>
        /// Регистрируем пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp( SignUpModel model )
        {
            if( !ModelState.IsValid )
            {
                return View( model );
            }

            if( await _accountService.IsUserSignUpAsync( model.Email ) )
            {
                ModelState.AddModelError( "email", "Аккаунт с таким e-mail адресом уже существует" );
                return View( model );
            }

            var result = new SignUpResultModel();
            try
            {
                if( await _accountService.IsTemporaryUserAsync( Guid.Parse( Request.Cookies["id"] ) ) )
                {
                    model.Id = Guid.Parse( Request.Cookies["id"] );
                    await _accountService.ActivateTemporaryAccountAsync( model );
                }
                else
                {
                    await _accountService.SignUpAsync( model );
                }

                result.AlertType = "alert-info";
                result.AlertMessage = "Регистрация прошла успешно";
            }
            catch( Exception )
            {
                result.AlertType = "alert-danger";
                result.AlertMessage = "Произошла ошибка. Свяжитесь с администратором";
            }

            return View( "SignUpResult", result );
        }

        /// <summary>
        /// Отрисовываем страницу авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SignIn() => View();

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn( SignInModel model )
        {
            if( !ModelState.IsValid )
            {
                return View( model );
            }

            var (isSuccess, errors) = await _accountService.ValidateAsync( model.Email, model.Password );
            if( !isSuccess )
            {
                ModelState.AddModelErrors( errors );
                return View( model );
            }

            await AuthenticateAsync( model.Email );
            return RedirectToAction( "Index", "Home" );
        }

        /// <summary>
        /// Деавторизация пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync( CookieAuthenticationDefaults.AuthenticationScheme );
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction( "Index", "Home" );
        }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Profile( Guid? id )
        {
            id ??= User.GetId();
            if( id == null )
            {
                return RedirectToAction( "SignIn" );
            }

            var model = await _accountService.GetUserExtendedInfoAsync( id.Value );
            return View( model );
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {
            await _accountService.DeleteUserAsync( userId );
            return RedirectToAction( "Index", "Home" );
        }

        /// <summary>
        /// Аутентификация пользователя на низком уровне.
        /// Добавляем claims и проводим Cookie авторизацию.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [NonAction]
        private async Task AuthenticateAsync( string email )
        {
            var user = await _accountService.GetUserAsync( email );
            var claims = new List<Claim>
            {
                new Claim( ClaimTypes.Name, user.Email ),
                new Claim( DvClaimTypes.UserId, user.Id.ToString() ),
                new Claim( DvClaimTypes.IsAdmin, user.IsAdmin.ToString() )
            };
            var identity = new ClaimsIdentity( claims, "email" );
            await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal( identity )
            );
        }
    }
}