using System;

namespace Store.Web.Services
{
    public class UserIdentifierService
    {
        /// <summary>
        /// Возвращаем id пользователя.
        /// Либо пустой id, если пользователя нет
        /// </summary>
        public Guid GetUserId( Guid? userId, object tempId )
        {
            if( userId.HasValue || tempId != null )
            {
                return userId ?? Guid.Parse( tempId.ToString() );
            }
            return Guid.NewGuid();
        }
    }
}