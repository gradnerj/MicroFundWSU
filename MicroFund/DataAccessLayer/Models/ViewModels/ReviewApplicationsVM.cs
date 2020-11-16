using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.ViewModels
{
    public class ReviewApplicationsVM
    {
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public IEnumerable<Application> Applications { get; set; }
    }
}
