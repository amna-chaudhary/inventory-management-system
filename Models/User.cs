using System.ComponentModel.DataAnnotations;

namespace MVCPro.Models
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
