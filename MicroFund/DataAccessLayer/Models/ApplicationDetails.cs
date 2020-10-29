using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ApplicationDetails
    {
        public int Id { get; set; }

        [Display(Name = "Applicant")]
        public int ApplicantId { get; set; }

        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }

        public string StatusOfBusiness { get; set; }

        public DateTime StartedDate { get; set; }

        public string Industry { get; set; }

        public string ProductServiceDescription { get; set; }

        public string Website { get; set; }

        public string PrototypeFile { get; set; }

        public string IPDescription { get; set; }

        public string SalesDescription { get; set; }

        public bool HasExternalFunding { get; set; }

        public string MarketOpportunity { get; set; }

        public string TargetMarketDemographic { get; set; }

        public string ProjectedSalesDescription { get; set; }

        public string CompetitionDescription { get; set; }

        public string TeamDescription { get; set; }

        public float AmountRequested { get; set; }

        public string PlanForFunds { get; set; }

        public bool PreviousMicroFundRecipient { get; set; }

        public string HearAboutMicroFund { get; set; }

        public bool HaveAttendedMicroFunWorkshop { get; set; }

        public bool OneMillionCupsExperience { get; set; }

        public string SmallBusinessDevCenterCounselorDescription { get; set; }

        public string CompanyName { get; set; }
    }
}
