using System;
using System.Security.Claims;

namespace Store.Web.Security
{
    /// <summary>
    /// Расширения для claims.
    /// </summary>
    public static class ClaimsExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Guid? GetId( this ClaimsPrincipal user )
        {
            var strId = user.FindFirstValue( DvClaimTypes.UserId );
            return strId == null ? null : (Guid?)Guid.Parse( strId );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetLogin( this ClaimsPrincipal user )
            => user.FindFirstValue( ClaimTypes.Name );

        /// <summary>
        /// Является ли пользователь администратором
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsAdmin( this ClaimsPrincipal user )
            => user.HasBoolClaim( DvClaimTypes.IsAdmin );

        /// <summary>
        /// Имеются ли claims типа bool
        /// </summary>
        private static bool HasBoolClaim( this ClaimsPrincipal user, string claimType )
        {
            var cv = user.FindFirstValue( claimType );
            return cv?.Trim().ToLower() == "true";
        }
    }
}