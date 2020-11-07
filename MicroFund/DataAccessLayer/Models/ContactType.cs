using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }

        [Required]
        [StringLength(64)]
        public string ContactTypeDescription { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
