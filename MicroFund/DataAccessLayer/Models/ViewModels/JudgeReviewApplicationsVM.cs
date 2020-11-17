using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.ViewModels
{
    public class JudgeReviewApplicationsVM
    {
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public IEnumerable<Application> Applications { get; set; }
    }
}
