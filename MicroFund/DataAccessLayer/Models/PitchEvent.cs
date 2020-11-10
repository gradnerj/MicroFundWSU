using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models {
    public class PitchEvent {
        [Key]
        public int PitchId { get; set; }
        public DateTime PitchDate { get; set; }
        public float Cash { get; set; }
        public float Services { get; set; }
    }
}
