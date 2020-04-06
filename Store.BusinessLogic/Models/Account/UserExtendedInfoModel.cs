using System.Collections.Generic;
using Store.BusinessLogic.Models.Sales;

namespace Store.BusinessLogic.Models.Account
{
    /// <summary>
    /// Информация о пользователе в личном кабинете
    /// </summary>
    public class UserExtendedInfoModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }       
        
        /// <summary>
        /// Проведенные покупки
        /// </summary>
        public IEnumerable<TransactionModel> Sales { get; set; }
    }
}