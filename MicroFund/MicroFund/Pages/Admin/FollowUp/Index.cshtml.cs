using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Admin.FollowUp
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /*class AwardedApplicants
        {
            public string ApplicantName { get; set; }
            public string CompanyName { get; set; }
            public string ApplicantName { get; set; }

        }
        public IEnumerable<Application> Applications { get; set; }
        public IEnumerable<AwardHistory> AwardHistories { get; set; }*/

        public List<AwardHistory> AwardHistories { get; set; }
        public List<Question> Questions { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public void OnGet()
        {
            
            /*Applications = _context.Application.ToList();
            AwardHistories = _context.AwardHistory.ToList();

            foreach (var item in collection)
            {

            }*/

            /*// Create a collection of person-pet pairs. Each element in the collection
            // is an anonymous type containing both the person's name and their pet's name.
            var query = from application in Applications
                        join awardHistory in AwardHistories on application equals awardHistory.ApplicationId
                        select new { CompanyName = application.CompanyName,  AwardDate = awardHistory.AwardDate };

            foreach (var companyAndAward in query)
            {
                Console.WriteLine($"\"{companyAndAward.CompanyName}\" is owned by {companyAndAward.OwnerName}");
            }*/
        }
    }
}
