using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class PitchScorecard
    {
        [Display(Name = "Pitch")]
        public int PitchId { get; set; }

        [ForeignKey("PitchId")]
        public Pitch Pitch { get; set; }

        [Display(Name = "Application User")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int MarketValid { get; set; }

        public int ValueProp { get; set; }

        public int TargetCustomers { get; set; }

        public int Competition { get; set; }

        public int GoToStrat { get; set; }

        public int FinProjections { get; set; }

        public int ManagementTeam { get; set; }

        public int Status { get; set; }

        public int Presentation { get; set; }
    }
}
