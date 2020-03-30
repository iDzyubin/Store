using System;

namespace Store.BusinessLogic.Models.Sales
{
    public class SaleLine
    {
        public Guid Id { get; set; }
        
        public SaleStatus Status { get; set; }
        
        public decimal TotalPrice { get; set; }
    }

    public enum SaleStatus
    {
        Waiting,
        InProgress,
        Successful
    }
}