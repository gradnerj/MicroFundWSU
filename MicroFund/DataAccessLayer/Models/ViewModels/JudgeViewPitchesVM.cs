using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.ViewModels
{
    public class JudgeViewPitchesVM
    {
        public IEnumerable<PitchEvent> PitchEvents { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public IEnumerable<Pitch> Pitches { get; set; }
    }
}
