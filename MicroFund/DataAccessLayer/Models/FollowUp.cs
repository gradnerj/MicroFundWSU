using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class FollowUp
    {
        public int Id { get; set; }

        [Display(Name = "GrantPhase")]
        public int GrantPhaseId { get; set; }

        [ForeignKey("GrantPhaseId")]
        public GrantPhase GrantPhase { get; set; }

        public string Type { get; set; }

        public bool Response { get; set; }

        public DateTime ResponseDate { get; set; }

        public int JobsAdded { get; set; }

        public float SalesIncrease { get; set; }

        public bool Profitable { get; set; }

        public string Status { get; set; }

        public int NumberOfEmployees { get; set; }

        public float Revenue { get; set; }

        public bool Exit { get; set; }

        public bool Funding { get; set; }

        public float FundingAmount { get; set; }

        public string FundingType { get; set; }
    }
}
