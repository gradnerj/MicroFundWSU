using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace MicroFund.Pages.Admin.Pitch {
    public class PitchDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _util;
        public PitchDetailsModel(ApplicationDbContext context, IEmailSender util) {
            _context = context;
            _util = util;
        }

        public DataAccessLayer.Models.Pitch Pitch { get; set; }
        public ApplicationUser Applicant { get; set; }
        public IEnumerable<ScoreCard> Scores { get; set; }
        public string log = "gradnerj@gmail.com";
        public IEnumerable<ApplicationUser> Judges { get; set; }
        
        public async System.Threading.Tasks.Task OnGetAsync(int pitchid)
        {
            Pitch = _context.Pitch.Where(p => p.PitchId == pitchid)
                .Include(p => p.Application)
                .FirstOrDefault();
            Applicant = _context.ApplicationUsers.FirstOrDefault(a => a.Id == Pitch.Application.ApplicantId);
            Scores = _context.ScoreCard.Where(s => s.Pitch.Application.ApplicantId == Applicant.Id).AsEnumerable();
            await _util.SendEmailAsync(log, "MF Pitch Details", "PD");
            var judgeIds = _context.ScoreCard.Where(s => s.Pitch.Application.ApplicantId == Applicant.Id).Select(s => s.JudgeId).AsEnumerable().ToList();
            Judges = _context.ApplicationUsers.Where(j => judgeIds.Contains(j.Id)).AsEnumerable();
        }
    }
}
