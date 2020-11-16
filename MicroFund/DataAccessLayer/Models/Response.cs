using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Response
    {
        public int ResponseId { get; set; }

        [Required]
        [Display(Name = "Application")]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [Required]
        [Display(Name = "Question")]
        public int QuestionId { get; set; }

        [Required]
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        [Required]
        [StringLength(750)]
        public string ResponseDescription { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
