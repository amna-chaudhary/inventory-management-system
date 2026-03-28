using System.ComponentModel.DataAnnotations;

namespace MVCPro.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string VendorType { get; set; }

        [StringLength(10)]
        public string Salutation { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string Phone { get; set; }

        public string DocumentPath { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingCity { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingState { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingCountry { get; set; }

        [Required]
        [StringLength(20)]
        public string BillingPostalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingCity { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingState { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingCountry { get; set; }

        [Required]
        [StringLength(20)]
        public string ShippingPostalCode { get; set; }
    }
}
