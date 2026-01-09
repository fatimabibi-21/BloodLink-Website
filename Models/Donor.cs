using System.ComponentModel.DataAnnotations;

namespace BloodLink.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}