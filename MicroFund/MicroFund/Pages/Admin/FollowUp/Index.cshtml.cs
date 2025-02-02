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

        public List<AwardHistory> AwardHistories30Days { get; set; }
        public List<AwardHistory> AwardHistories60Days { get; set; }
        public List<AwardHistory> AwardHistories { get; set; }
        public void OnGet()
        {
            List<Application> Applications = _context.Application.ToList();
            AwardHistories30Days = new List<AwardHistory>();
            AwardHistories60Days = new List<AwardHistory>();
            AwardHistories = new List<AwardHistory>();
            //This retrieves the earliest award for each application and puts them into the AwardHistories list
            foreach (var application in Applications)
            {
                //Finds earliest award for each application
                AwardHistory TempAward = _context.AwardHistory.Where(a => a.ApplicationId == application.ApplicationId).OrderBy(a => a.AwardDate).FirstOrDefault();
                if (TempAward != null)
                {
                    TempAward.Application = _context.Application.FirstOrDefault(a => a.ApplicationId == TempAward.ApplicationId);
                    AwardHistories.Add(TempAward);
                }
            }

            //Filters awards into two categories depending on how old they are
            foreach (var awardHistory in AwardHistories)
            {
                if ((DateTime.Now - awardHistory.AwardDate).TotalDays >= 30)
                {
                    AwardHistories30Days.Add(awardHistory);
                    if ((DateTime.Now - awardHistory.AwardDate).TotalDays >= 60)
                    {
                        AwardHistories60Days.Add(awardHistory);
                    }
                }
            }
        }
    }
}
