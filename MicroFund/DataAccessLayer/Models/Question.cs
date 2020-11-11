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
        [Display(Name = "Category")]
        public int QuestionCategoryId { get; set; }

        [Display(Name = "Question Category")]
        [ForeignKey("QuestionCategoryId")]
        public QuestionCategory QuestionCategory { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(250)]
        public string QuestionDescription { get; set; }

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
    }
}
