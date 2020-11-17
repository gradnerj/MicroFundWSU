using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.ViewModels
{
    public class ApplicantViewApplicationsVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Application> Applications { get; set; }
    }
}
