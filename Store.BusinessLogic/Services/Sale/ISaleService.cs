using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.BusinessLogic.Models.Sales;

namespace Store.BusinessLogic.Services.Sale
{
    /// <summary>
    /// Сервис обработки продаж
    /// </summary>
    public interface ISaleService
    {
        /// <summary>
        /// Подтвердить продажу
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AcceptAsync( Guid userId );

        /// <summary>
        /// Отменить транзакцию
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        Task CancelAsync( Guid transactionId );

        /// <summary>
        /// Возвращает в личный кабинет все транзакции,
        /// проведенные пользователем
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TransactionModel>> GetTransactionsAsync( Guid userId );
    }
}