using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ScoreCardField
    {
        public int ScoreCardFieldId { get; set; }

        [Required]
        [Display(Name = "ScoringCategory")]
        public int ScoringCategoryId { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("ScoringCategoryId")]
        public ScoringCategory ScoringCategory { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(250)]
        public string ScoreCardFieldDescription { get; set; }

        [Required]
        public float Weight { get; set; }

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
