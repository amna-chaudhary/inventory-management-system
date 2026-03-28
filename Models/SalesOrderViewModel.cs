using System.Collections.Generic;
using System;

namespace MVCPro.Models
{
    public class SalesOrderViewModel
    {
        // Add Id and TotalAmount to the ViewModel
        public int Id { get; set; }  // Add this property to bind to SalesOrder's Id
        public string CustomerName { get; set; }
        public string SalesOrderNumber { get; set; }
        public DateTime? ExpectedShipmentDate { get; set; }
        public string PaymentTerms { get; set; }
        public decimal TotalAmount { get; set; }  // Add this property to bind to the TotalAmount property
        public int CustomerId { get; set; }  // This will bind to the customer dropdown

        public List<int> ProductIds { get; set; }  // List of Product IDs
        public List<int> Quantities { get; set; }  // List of Quantities for the corresponding Products
    }
}
