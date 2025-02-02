﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ExternalFunding
    {
        public int ExternalFundingId { get; set; }

        [Required]
        [Display(Name = "Application")]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        [StringLength(64)]
        public string Source { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
