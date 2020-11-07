using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }

        [Required]
        [Display(Name = "ContactType")]
        public int ContactTypeId { get; set; }

        [Required]
        [ForeignKey("ContactTypeId")]
        public ContactType ContactType { get; set; }

        [Required]
        [Display(Name = "Applicant")]
        public string ApplicantId { get; set; }

        [Required]
        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }

        [Required]
        [StringLength(64)]
        public string ContactInfoDetail { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
