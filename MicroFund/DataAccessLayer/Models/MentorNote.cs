using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class MentorNote
    {
        public int MentorNoteId { get; set; }

        [Required]
        [Display(Name = "MentorAssignment")]
        public int MentorAssignmentId { get; set; }

        
        [ForeignKey("MentorAssignmentId")]
        public MentorAssignment MentorAssignment { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}")]
        public DateTime MeetingDate { get; set; }

        [Required]
        public string Notes { get; set; }

        [Display(Name = "File Attachment")]
        public string MentorNoteFileAttachment { get; set; }

        [Required]
        [Display(Name = "Updated By")]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [Display(Name = "Is Archived")]
        public bool IsArchived { get; set; }

        [NotMapped]
        public bool IsApproved { get; set; }
    }
}
