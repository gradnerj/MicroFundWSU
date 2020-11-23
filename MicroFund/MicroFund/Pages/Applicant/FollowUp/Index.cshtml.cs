using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Applicant.FollowUp
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<AwardHistory> Award30DayFollowUp { get; set; }
        public List<AwardHistory> Award60DayFollowUp { get; set; }
        /*public List<AwardHistory> AwardHistories { get; set; }*/

        public void OnGet()
        {
            string userId = _userManager.GetUserId(User);
            //Gets all the applications of the current user
            List<Application> Applications = _context.Application.Where(a => a.ApplicantId == userId).ToList();
            Award30DayFollowUp = new List<AwardHistory>();
            Award60DayFollowUp = new List<AwardHistory>();
            /*AwardHistories = new List<AwardHistory>();*/
            //This retrieves the earliest award for each application and puts them into the AwardHistories list
            foreach (var application in Applications)
            {
                //Finds earliest award for each application
                AwardHistory TempAward = _context.AwardHistory.Where(a => a.ApplicationId == application.ApplicationId).OrderBy(a => a.AwardDate).FirstOrDefault();
                if (TempAward != null)
                {
                    TempAward.Application = _context.Application.FirstOrDefault(a => a.ApplicationId == TempAward.ApplicationId);
                    //Filters awards into two categories depending on how old they are
                    if ((DateTime.Now - TempAward.AwardDate).TotalDays >= 30)
                    {
                        Award30DayFollowUp.Add(TempAward);
                        if ((DateTime.Now - TempAward.AwardDate).TotalDays >= 60)
                        {
                            Award60DayFollowUp.Add(TempAward);
                        }
                    }
                }
            }

            /*//Filters awards into two categories depending on how old they are
            foreach (var awardHistory in AwardHistories)
            {
                if ((DateTime.Now - awardHistory.AwardDate).TotalDays >= 30)
                {
                    Award30DayFollowUp.Add(awardHistory);
                    if ((DateTime.Now - awardHistory.AwardDate).TotalDays >= 60)
                    {
                        Award60DayFollowUp.Add(awardHistory);
                    }
                }
            }*/

        }
    }
}
