using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.DataModels
{
    /// <summary>
    /// Статусы товара пользователя
    /// </summary>
    public enum SaleItemStatus
    {
        /// <summary>
        /// В корзине
        /// </summary>
        [Display(Name = "В корзине")]
        InBasket = 0,
        
        /// <summary>
        /// Продано
        /// </summary>
        [Display(Name = "Продано")]
        Sold = 1,
        
        /// <summary>
        /// Отменено
        /// </summary>
        [Display(Name = "Отменено")]
        Canceled = 2
    }

    /// <summary>
    /// Статус транзакции
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        /// Отсутствует
        /// </summary>
        [Display(Name = "Отсутствует")]
        None = 0,
        
        /// <summary>
        /// Подтверждено
        /// </summary>
        [Display(Name = "Подтверждено")]
        Accepted = 1,
        
        /// <summary>
        /// Отменено
        /// </summary>
        [Display(Name = "Отменено")]
        Canceled = 2
    }

    /// <summary>
    /// Статус пользователя
    /// </summary>
    public enum UserStatus
    {
        [Display(Name = "Отсутствует")]
        None,
        
        [Display(Name = "Подтвержен")]
        Approved,
        
        [Display(Name = "Удален")]
        Deleted,
        
        [Display(Name = "Временный пользователь")]
        Temporary
    }
}