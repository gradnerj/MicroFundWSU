using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class FollowUp
    {
        public int FollowUpId { get; set; }

        [Required]
        [Display(Name = "Application")]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [Required]
        [Display(Name = "FollowUpType")]
        public int FollowUpTypeId { get; set; }

        [Required]
        [ForeignKey("FollowUpTypeId")]
        public FollowUpType FollowUpType { get; set; }

        [Required]
        public DateTime FollowUpDate { get; set; }

        public bool Response { get; set; }

        public DateTime ResponseDate { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
