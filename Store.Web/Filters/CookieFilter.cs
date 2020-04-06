using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Store.Web.Filters
{
    /// <summary>
    /// Фильтр обработки cookie.
    /// </summary>
    public class CookieFilter : Attribute, IActionFilter
    {
        /// <summary>
        /// Remark: применяется для временных пользователей.
        /// Если пользователь не залогинен - для него создается уникальный идентификатор,
        /// который складывается в Cookie.
        /// </summary>
        public void OnActionExecuting( ActionExecutingContext context )
        {
            var cookies = context.HttpContext.Request.Cookies;
            if( !cookies.ContainsKey( "id" ) )
            {
                var userId = Guid.NewGuid().ToString();
                context.HttpContext.Response.Cookies.Append( "id", userId );
            }

            if( context.Controller is Controller controller )
            {
                controller.TempData["id"] = cookies["id"];
            }
        }

        public void OnActionExecuted( ActionExecutedContext context )
        {
        }
    }
}