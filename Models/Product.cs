using System.ComponentModel.DataAnnotations;

namespace MVCPro.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required] // Add this if this field should be required
        [StringLength(50)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemCategory { get; set; }

        [Required]
        [StringLength(50)]
        public string Weight { get; set; }

        public string Description { get; set; }

        [Range(0, int.MaxValue)] // Add appropriate validation
        public int Quantity { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal CostPrice { get; set; }

        [StringLength(255)]
        public string VendorCompany { get; set; }

        public string PurchaseDescription { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal SellingPrice { get; set; }

        public string SellingDescription { get; set; }
    }
}
