using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MicroFund.Pages.Admin.Pitch {
    public class PitchDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public PitchDetailsModel(ApplicationDbContext context) {
            _context = context;
        }

        public DataAccessLayer.Models.Pitch Pitch { get; set; }
        public ApplicationUser Applicant { get; set; }
        public IEnumerable<ScoreCard> Scores { get; set; }
        public IEnumerable<ApplicationUser> Judges { get; set; }
        public void OnGet(int pitchid)
        {
            Pitch = _context.Pitch.Where(p => p.PitchId == pitchid)
                .Include(p => p.Application)
                .FirstOrDefault();
            Applicant = _context.ApplicationUsers.FirstOrDefault(a => a.Id == Pitch.Application.ApplicantId);
            Scores = _context.ScoreCard.Where(s => s.Pitch.Application.ApplicantId == Applicant.Id).AsEnumerable();
            var judgeIds = _context.ScoreCard.Where(s => s.Pitch.Application.ApplicantId == Applicant.Id).Select(s => s.JudgeId).AsEnumerable().ToList();
            Judges = _context.ApplicationUsers.Where(j => judgeIds.Contains(j.Id)).AsEnumerable();
        }
    }
}
