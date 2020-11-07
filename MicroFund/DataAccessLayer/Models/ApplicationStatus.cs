using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ApplicationStatus
    {
        public int ApplicationStatusId { get; set; }

        [Required]
        [StringLength(32)]
        public string StatusDescription { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
