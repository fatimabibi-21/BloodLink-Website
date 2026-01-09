using System;
using System.ComponentModel.DataAnnotations;

namespace BloodLink.Models
{
    public class BloodRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        // Allow NULLs from the DB; keep a default when creating new objects.
        public DateTime? RequestDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";
        public string Priority { get; set; } = "Normal"; // Default value
    }
}