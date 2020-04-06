using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Web.Security;

namespace Store.Web.Filters
{
    /// <summary>
    /// Обработка claims пользователя.
    /// Проверка, что он авторизован
    /// Если авторизован - берем его userId
    /// Если он админ - отмечаем, что имеет админские права
    /// </summary>
    public class UserClaimsFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting( ActionExecutingContext context )
        {
            var controller = context.Controller as Controller;
            var user = controller.User;
            var viewBag = controller.ViewBag;

            viewBag.UserId = user.GetId();
            viewBag.IsAuthorized = viewBag.UserId != null;
            viewBag.IsAdmin = user.IsAdmin();

            base.OnActionExecuting( context );
        }
    }
}