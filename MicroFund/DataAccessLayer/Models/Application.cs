using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }

        [Required]
        [Display(Name = "Applicant")]
        public string ApplicantId { get; set; }

        [Required]
        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }

        [Required]
        [Display(Name = "ApplicationStatus")]
        public int ApplicationStatusId { get; set; }

        [Required]
        [ForeignKey("ApplicationStatusId")]
        public ApplicationStatus ApplicationStatus { get; set; }

        [Required]
        public DateTime ApplicationCreationDate { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
