using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class MentorAssignment
    {
        public int MentorAssignmentId { get; set; }

        [Required]
        [Display(Name = "Mentor")]
        public string MentorId { get; set; }

        
        [ForeignKey("MentorId")]
        public IdentityUser Mentor { get; set; }

        [Required]
        [Display(Name = "Application")]
        public int ApplicationId { get; set; }

        
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [Required]
        public DateTime DateAssigned { get; set; }

        public DateTime ApprovedToPitchDate { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
