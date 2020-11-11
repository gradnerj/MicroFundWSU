using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Required]
        [Display(Name = "QuestionCategory")]
        public int QuestionCategoryId { get; set; }

        [ForeignKey("QuestionCategoryId")]
        public QuestionCategory QuestionCategory { get; set; }

        [Required]
        [StringLength(250)]
        public string QuestionDescription { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
