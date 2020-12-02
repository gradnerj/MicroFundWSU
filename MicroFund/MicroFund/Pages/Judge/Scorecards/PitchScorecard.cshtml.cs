using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ViewModels;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace MicroFund.Pages.Judge.Scorecards
{
    public class PitchScorecardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public string score = "";
        public string comment = "";
        private readonly IEmailSender _util;
        private readonly IRepository _repository;
        public PitchScorecardModel(IRepository repository, ApplicationDbContext context, IEmailSender util) {
            _context = context;
            _util = util;
            _repository = repository;
        }

        [BindProperty]
        public List<ScoreCardField> ScoreCardFields { get; set; }

        public ScoreCard ScoreCard { get; set; }
        public JudgeViewPitchesVM JudgeViewPitchesVM { get; set; }
        public int PitchId { get; set; }

        public async Task OnGetAsync(int id)
        {
            PitchId = id;
            await _util.SendEmailAsync(StaticDetails.Log, "MF Pitch SC get", "PSC");
            ScoreCardFields = await _context.ScoreCardField.Where(x => x.ScoringCategoryId == 1).ToListAsync();

            JudgeViewPitchesVM = new JudgeViewPitchesVM
            {
                PitchEvents = await _repository.GetAllPitchEventsAsync(),
                Pitches = _context.Pitch.Include(a => a.Application).ToList().AsEnumerable(),
                ApplicationUsers = await _repository.GetAllUsersAsync()
            };


        }

        public async Task<IActionResult> OnPostAsync()
        {
            var pitchId = Int32.Parse(Request.Form["PitchId"].ToString());
            var judgeId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            ScoreCardFields = await _context.ScoreCardField.Where(x => x.ScoringCategoryId == 1).ToListAsync();

            foreach (var field in ScoreCardFields)
            {
                ScoreCard = new ScoreCard
                {
                    PitchId = pitchId,
                    Pitch = _context.Pitch.Where(x => x.PitchId == pitchId).FirstOrDefault(),
                    JudgeId = judgeId,
                    Judge = _context.ApplicationUsers.Where(x => x.Id == judgeId).FirstOrDefault(),
                    ScoreCardFieldId = _context.ScoreCardField.Where(x => x.ScoreCardFieldDescription == field.ScoreCardFieldDescription).FirstOrDefault().ScoreCardFieldId,
                    ScoreCardField = _context.ScoreCardField.Where(x => x.ScoreCardFieldDescription == field.ScoreCardFieldDescription).FirstOrDefault(),
                    Comment = Request.Form[field.ScoreCardFieldDescription + "Comment"],
                    Score = Int32.Parse(Request.Form[field.ScoreCardFieldDescription + "Score"].ToString()),
                    UpdatedBy = judgeId,
                    UpdatedDate = DateTime.Now,
                    IsArchived = false
                };
                await _util.SendEmailAsync(log, "MF Pitch SC post", "PSC");
                _context.ScoreCard.Add(ScoreCard);
            }
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
        private string log = "gradnerj@gmail.com";
    }
}
