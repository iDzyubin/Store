using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.DataAccess.DataModels;

namespace Store.DataAccess.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория продаж
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Подтвердить продажу товара
        /// </summary>
        /// <param name="userId">Покупатель</param>
        Task AcceptAsync( Guid userId );

        /// <summary>
        /// Отмена продажи товара
        /// </summary>
        /// <param name="transactionId">Номер отменяемой транзакции</param>
        Task CancelAsync( Guid transactionId );

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<SaleItem>> GetSalesItemsAsync( Guid userId );
    }
}