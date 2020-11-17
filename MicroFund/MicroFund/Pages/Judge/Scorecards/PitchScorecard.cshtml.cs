using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Judge.Scorecards
{
    public class PitchScorecardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public int PitchId;
        public string score = "";
        public string comment = "";

        public PitchScorecardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<ScoreCardField> ScoreCardFields { get; set; }

        public ScoreCard ScoreCard { get; set; }

        public async Task OnGetAsync(int id)
        {
            PitchId = id;

            ScoreCardFields = await _context.ScoreCardField.Where(x => x.ScoringCategoryId == 1).ToListAsync();
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

                _context.ScoreCard.Add(ScoreCard);
            }
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
