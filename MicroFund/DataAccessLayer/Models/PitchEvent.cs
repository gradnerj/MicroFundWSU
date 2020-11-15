using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models {
    public class PitchEvent {
        public int PitchEventId { get; set; }
        public DateTime PitchDate { get; set; }
        public float Cash { get; set; }
        public float Services { get; set; }
    }
}
