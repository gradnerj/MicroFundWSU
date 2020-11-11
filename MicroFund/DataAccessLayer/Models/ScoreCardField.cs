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

        
        [ForeignKey("ScoringCategoryId")]
        public ScoringCategory ScoringCategory { get; set; }

        [Required]
        [StringLength(128)]
        public string ScoreCardFieldName { get; set; }

        [Required]
        [StringLength(250)]
        public string ScoreCardFieldDescription { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
