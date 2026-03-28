using System;

namespace MVCPro.Models
{
    public class SalesOrderItem
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }  // Foreign key to SalesOrder
        public int ProductId { get; set; }  // Foreign key to Product
        public int Quantity { get; set; }
        public decimal Price { get; set; }  // Price of the product at the time of the order

        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
