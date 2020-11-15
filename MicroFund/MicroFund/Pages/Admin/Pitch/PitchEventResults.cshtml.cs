using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MicroFund.Pages.Admin.Pitch {
    public class PitchEventResultsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public PitchEventResultsModel(ApplicationDbContext context) {
            _context = context;
        }
        public PitchEvent PEvent { get; set; }
        public IQueryable<ScoreCard> Scores { get; set; }

        public IQueryable<DataAccessLayer.Models.Pitch> Pitches { get; set; }

        public IQueryable<ApplicationUser> Presenters { get; set; }
        public IQueryable<ApplicationUser> Judges { get; set; }
        public void OnGet(int eventid)
        {
            PEvent = _context.PitchEvents.FirstOrDefault(e => e.PitchId == eventid);
            Pitches = _context.Pitch.Where(p => p.PitchDate == PEvent.PitchDate).Include(p => p.Application);
            var pitchIds = Pitches.Select(p => p.PitchId).ToList();
            var userIds = Pitches.Select(p => p.Application.ApplicantId).ToList();
            Scores = _context.ScoreCard.Where(s => pitchIds.Contains(s.PitchId)).Include(s => s.Judge);
            Presenters = _context.ApplicationUsers.Where(u => userIds.Contains(u.Id));
            var judgeIds = Scores.Select(s => s.JudgeId).ToList();
            Judges = _context.ApplicationUsers.Where(j => judgeIds.Contains(j.Id));
        }
    }
}
