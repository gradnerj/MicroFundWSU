using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Applicant
    {
        [Key]
        [Required]
        [Display(Name = "Applicant")]
        public string ApplicantId { get; set; }

        [Required]
        [ForeignKey("ApplicantId")]
        public IdentityUser IdentityUser { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(64)]
        public string HighestEduCompleted { get; set; }

        [Required]
        public bool CurrentStudent { get; set; }

        public bool WSUEntrepreneurshipMinor { get; set; }

        public bool WSUEmployee { get; set; }

        [StringLength(64)]
        public string WSUNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string RaceEthnicity { get; set; }

        [Required]
        public float Income { get; set; }

        [Required]
        public string ResidenceEnvironment { get; set; }

        [Required]
        public bool VeteranStatus { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
