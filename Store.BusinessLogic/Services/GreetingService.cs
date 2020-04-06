using System;

namespace Store.BusinessLogic.Services
{
    /// <summary>
    /// Сервис для сообщения на главном экране
    /// </summary>
    public class GreetingService
    {
        /// <summary>
        /// Возвращаем приветствие
        /// </summary>
        public string GetGreeting()
        {
            var currentHour = DateTime.Now.Hour;
            if( currentHour >= 6 && currentHour <= 12 ) return "Доброе утро";
            if( currentHour > 12 && currentHour < 17 ) return "Добрый день";
            return "Добрый вечер";
        }
    }
}