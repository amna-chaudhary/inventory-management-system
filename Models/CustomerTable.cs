using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPro.Models
{
    public class CustomerTable
    {
        [Key]
        public int Id { get; set; }

        public string CustomerType { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPostalCode { get; set; }

        // ✅ Add this for relationship
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
