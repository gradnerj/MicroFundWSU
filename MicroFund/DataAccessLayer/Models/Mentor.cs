using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Mentor
    {
        public int Id { get; set; }

        [Display(Name = "Application Details")]
        public int ApplicationDetailsId { get; set; }

        [ForeignKey("ApplicationDetailsId")]
        public ApplicationDetails ApplicationDetails { get; set; }

        public string MentorName { get; set; }

        public DateTime DateAssigned { get; set; }

        public int NumberOfVisits { get; set; }

        public DateTime ApprovedToPitchDate { get; set; }
    }
}
