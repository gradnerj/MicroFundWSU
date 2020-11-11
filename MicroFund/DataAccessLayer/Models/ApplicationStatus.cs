﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ApplicationStatus
    {
        public int ApplicationStatusId { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(32)]
        public string StatusDescription { get; set; }

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
