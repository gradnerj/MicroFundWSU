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

        [Required]
        [ForeignKey("MentorAssignmentId")]
        public MentorAssignment MentorAssignment { get; set; }

        [Required]
        public DateTime MeetingDate { get; set; }

        [Required]
        [StringLength(250)]
        public string Notes { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
