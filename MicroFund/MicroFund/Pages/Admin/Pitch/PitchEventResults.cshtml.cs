using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace MicroFund.Pages.Admin.Pitch {
    public class PitchEventResultsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _util;
        public PitchEventResultsModel(ApplicationDbContext context, IEmailSender util) {
            _context = context;
            _util = util;
        }
        public PitchEvent PEvent { get; set; }
        public IQueryable<ScoreCard> Scores { get; set; }

        public IQueryable<DataAccessLayer.Models.Pitch> Pitches { get; set; }

        public IQueryable<ApplicationUser> Presenters { get; set; }
        public IQueryable<ApplicationUser> Judges { get; set; }
        public string log = StaticDetails.Log;
        public string[] ScoringCategories { get; set; }
        public List<float> AverageCategoryScores { get; set; }

        public List<float> AveragePitchScores { get; set; }
        public List<string> CompanyNames { get; set; }
        public async System.Threading.Tasks.Task OnGetAsync(int eventid)
        {
            PEvent = _context.PitchEvents.FirstOrDefault(e => e.PitchEventId == eventid);
            Pitches = _context.Pitch.Where(p => p.PitchDate == PEvent.PitchDate).Include(p => p.Application);
            await _util.SendEmailAsync(log, "MF Pitch Event Results", "PEP");
            var pitchIds = Pitches.Select(p => p.PitchId).ToList();
            var userIds = Pitches.Select(p => p.Application.ApplicantId).ToList();
            Scores = _context.ScoreCard.Where(s => pitchIds.Contains(s.PitchId)).Include(s => s.Judge).Include(s => s.ScoreCardField);
            Presenters = _context.ApplicationUsers.Where(u => userIds.Contains(u.Id));
            var judgeIds = Scores.Select(s => s.JudgeId).ToList();
            Judges = _context.ApplicationUsers.Where(j => judgeIds.Contains(j.Id));
            ScoringCategories = Scores.Select(s => s.ScoreCardField.ScoreCardFieldDescription).Distinct().ToArray();
            AverageCategoryScores = new List<float>();

            
            
            foreach (var c in ScoringCategories) {
                var sum = Scores.Where(x => x.ScoreCardField.ScoreCardFieldDescription == c).AsEnumerable().ToList().Sum(s => s.Score);
                float avg = (float)sum / (float)Scores.Where(x => x.ScoreCardField.ScoreCardFieldDescription == c).AsEnumerable().ToList().Count;
                AverageCategoryScores.Add(avg);
                    
            }
            AveragePitchScores = new List<float>();
            var numJudges = Judges.AsEnumerable().ToList().Count;
            foreach (var p in Presenters.AsEnumerable().ToList()) { 
                float totalScore = 0;
                foreach (var c in ScoringCategories) {
                    totalScore += Scores.FirstOrDefault(s => (s.Pitch.Application.ApplicantId == p.Id) && (s.ScoreCardField.ScoreCardFieldDescription == c)).Score;
                }
                totalScore = (float)totalScore / (float)numJudges;
                AveragePitchScores.Add(totalScore);
            }
            CompanyNames = new List<string>();
            foreach(var p in Pitches.AsEnumerable().ToList()) {
                CompanyNames.Add(p.Application.CompanyName);
            }
        }
    }
}
