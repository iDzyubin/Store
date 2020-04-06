using System;
using Store.DataAccess.DataModels;

namespace Store.BusinessLogic.Models.Sales
{
    /// <summary>
    /// Основная информация о транзакции
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// Id транзакции
        /// </summary>
        public Guid TransactionId { get; set; }
        
        /// <summary>
        /// Статус транзакции
        /// </summary>
        public TransactionStatus Status { get; set; }
        
        /// <summary>
        /// Сумма транзакции
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}