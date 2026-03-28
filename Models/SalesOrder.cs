using System;
using System.Collections.Generic;

namespace MVCPro.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string SalesOrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ExpectedShipmentDate { get; set; }
        public string PaymentTerms { get; set; }
        public decimal TotalAmount { get; set; }

        public int? CustomerTable_Id { get; set; }  // Foreign key to CustomerTable
        public virtual CustomerTable CustomerTable { get; set; }  // Navigation property

        // Add this navigation property for SalesOrderItems
        public virtual ICollection<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
