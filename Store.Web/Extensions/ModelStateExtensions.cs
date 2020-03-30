using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Store.Web.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrors( 
            this ModelStateDictionary modelState, 
            Dictionary<string, string> errors )
        {
            foreach( var (key, error) in errors )
            {
                modelState.AddModelError(key, error);
            }
        }
    }
}