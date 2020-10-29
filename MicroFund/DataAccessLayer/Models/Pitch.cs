using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Pitch
    {
        public int Id { get; set; }

        [Display(Name = "Application Details")]
        public int ApplicationDetailsId { get; set; }

        [ForeignKey("ApplicationDetailsId")]
        public ApplicationDetails ApplicationDetails { get; set; }

        public DateTime PitchDate { get; set; }
    }
}
