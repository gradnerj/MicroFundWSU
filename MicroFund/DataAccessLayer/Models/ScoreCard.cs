using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ScoreCard
    {
        public int ScoreCardId { get; set; }

        [Required]
        [Display(Name = "Pitch")]
        public int PitchId { get; set; }

        [Required]
        [ForeignKey("PitchId")]
        public Pitch Pitch { get; set; }

        [Required]
        [Display(Name = "Judge")]
        public string JudgeId { get; set; }

        [Required]
        [ForeignKey("JudgeId")]
        public IdentityUser Judge { get; set; }

        [Required]
        [Display(Name = "ScoreCardField")]
        public int ScoreCardFieldId { get; set; }

        [Required]
        [ForeignKey("ScoreCardFieldId")]
        public ScoreCardField ScoreCardField { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
