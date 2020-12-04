using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Admin.Pitch
{
    public class AwardPitchModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AwardPitchModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AwardHistory AwardHistory { get; set; }
        public Application Application { get; set; }
        //This piece is here because creating a pitch is not matching an application to the pitch properly yet
        public string ApplicationCompanyName { get; set; }
        public IQueryable<AwardHistory> PreviousAwards { get; set; }
        public DataAccessLayer.Models.Pitch Pitch { get; set; }
        public float RemainingPitchEventFunds { get; set; }
        public float RemainingPitchEventCash { get; set; }
        public float RemainingPitchEventServices { get; set; }
        public int? SelectedPitch { get; set; }

        public IActionResult OnGet(int? pitchId)
        {
            //If pitchId parameter is 0 (defaulted value when not passing in a value) return NotFound
            if (pitchId == 0)
            {
                return NotFound();
            }

            SelectedPitch = pitchId;

            //Find Pitch and return NotFound if it doesn't exist
            Pitch = _context.Pitch.FirstOrDefault(p => p.PitchId == pitchId);
            if (Pitch == null)
            {
                return NotFound();
            }

            Application = _context.Application.FirstOrDefault(a => a.ApplicationId == Pitch.ApplicationId);
            ApplicationCompanyName = Application.CompanyName;

            RemainingPitchEventCash = _context.PitchEvents.FirstOrDefault(p => p.PitchEventId == Pitch.PitchEventId).Cash;
            RemainingPitchEventServices = _context.PitchEvents.FirstOrDefault(p => p.PitchEventId == Pitch.PitchEventId).Services;
            RemainingPitchEventFunds = RemainingPitchEventCash + RemainingPitchEventServices;

            foreach (var award in _context.AwardHistory.ToList())
            {
                if (award.PitchEventId == Pitch.PitchEventId)
                {
                    RemainingPitchEventCash -= award.CashAmount;
                    RemainingPitchEventServices -= award.ServicesAmount;
                    RemainingPitchEventFunds -= (award.CashAmount + award.ServicesAmount);
                }
            }

            PreviousAwards = _context.AwardHistory.Where(a => a.Application.ApplicantId == Application.ApplicantId);

            return Page();
        }

        public IActionResult OnPost()
        {
            var PitchId = Request.Form["PitchId"];
            Pitch = _context.Pitch.FirstOrDefault(p => p.PitchId == Int32.Parse(PitchId.ToString()));
            AwardHistory.Application = _context.Application.FirstOrDefault(a => a.ApplicationId == Pitch.ApplicationId);
            AwardHistory.ApplicationId = Pitch.ApplicationId;
            AwardHistory.PitchEvent = _context.PitchEvents.FirstOrDefault(p => p.PitchEventId == Pitch.PitchEventId);
            AwardHistory.PitchEventId = Pitch.PitchEventId;
            AwardHistory.AwardDate = DateTime.Now;
            //AwardHistory.UpdatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            AwardHistory.UpdatedBy = Request.Form["UserId"];
            AwardHistory.UpdatedDate = DateTime.Now;
            AwardHistory.IsArchived = false;

            //This next portion is purely for testing
            if (!ModelState.IsValid)
            {
                int temp = 1;
            }
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            _context.AwardHistory.Add(AwardHistory);

            //Creating 30 and 60 day Follow-up responses if there are none already created for the application
            List<Question> Questions30DayFollowUp = _context.Question.Where(q => q.QuestionCategoryId == 2).ToList();
            List<Response> Responses = _context.Response.Where(r => r.ApplicationId == Pitch.ApplicationId).ToList();
            bool AddResponses = true;
            foreach (var q in Questions30DayFollowUp)
            {
                foreach (var r in Responses)
                {
                    if (r.QuestionId == q.QuestionId)
                    {
                        AddResponses = false;
                    }
                }
            }
            if (AddResponses)
            {
                foreach (var q in Questions30DayFollowUp)
                {
                    Response TempResponse = new Response
                    {
                        ApplicationId = Pitch.ApplicationId,
                        QuestionId = q.QuestionId,
                        ResponseDescription = "N/A",
                        UpdatedBy = Request.Form["UserId"],
                        UpdatedDate = DateTime.Now,
                        IsArchived = false
                    };
                    _context.Response.Add(TempResponse);
                }
                List<Question> Questions60DayFollowUp = _context.Question.Where(q => q.QuestionCategoryId == 4).ToList();
                foreach (var q in Questions60DayFollowUp)
                {
                    Response TempResponse = new Response
                    {
                        ApplicationId = Pitch.ApplicationId,
                        QuestionId = q.QuestionId,
                        ResponseDescription = "N/A",
                        UpdatedBy = Request.Form["UserId"],
                        UpdatedDate = DateTime.Now,
                        IsArchived = false
                    };
                    _context.Response.Add(TempResponse);
                }
            }
            _context.SaveChanges();

            return RedirectToPage(new { pitchId = Pitch.PitchId });
        }
    }
}
