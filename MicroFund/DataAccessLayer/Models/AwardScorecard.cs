using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class AwardScorecard
    {
        [Display(Name = "Pitch")]
        public int PitchId { get; set; }

        [ForeignKey("PitchId")]
        public Pitch Pitch { get; set; }

        [Display(Name = "Application User")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int Geographics { get; set; }

        public int Diversity { get; set; }

        public int ProbabilityOfSuccess { get; set; }

        public int NumberOfJobs { get; set; }

        public int BenefitToCompany { get; set; }

        public int BenefitToCommunity { get; set; }

        public int Returning { get; set; }

        public int FollowOnApp { get; set; }

        public int GreaterOneKRevenue { get; set; }
    }
}
