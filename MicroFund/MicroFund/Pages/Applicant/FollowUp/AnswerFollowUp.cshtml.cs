using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Applicant.FollowUp
{
    public class AnswerFollowUpModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public int ApplicationId;
        public int FollowUpTypeNum;
        public Application Application;
        public AnswerFollowUpModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public List<Response> Responses { get; set; }

        public IActionResult OnGet(int applicationId, int followUpTypeNum)
        {
            bool proceed = SetupResponses(applicationId, followUpTypeNum);
            if (proceed)
            {
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult OnPost()
        {
            SetupResponses(Int32.Parse(Request.Form["ApplicationId"]), Int32.Parse(Request.Form["FollowUpTypeNum"]));
            foreach (var r in Responses)
            {
                r.ResponseDescription = Request.Form[(r.Question.QuestionDescription + "Response")];
                if (r.ResponseDescription.Equals("") || r.ResponseDescription.Equals(null))
                {
                    r.ResponseDescription = "N/A";
                }
                r.UpdatedBy = _userManager.GetUserId(User);
                r.UpdatedDate = DateTime.Now;
                _context.Update(r);
            }
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

        public bool SetupResponses(int applicationId, int followUpTypeNum)
        {
            ApplicationId = applicationId;
            Application = _context.Application.FirstOrDefault(a => a.ApplicationId == applicationId);
            FollowUpTypeNum = followUpTypeNum;
            if (followUpTypeNum == 30)
            {
                //Retrieve 30 FollowUp Responses
                Responses = _context.Response.Where(r => r.Question.QuestionCategoryId == 2 && r.ApplicationId == applicationId).ToList();
                //Sets all the response.Questions equal to the question
                foreach (var r in Responses)
                {
                    foreach (var q in _context.Question.Where(q => q.QuestionCategoryId == 2).ToList())
                    {
                        if (q.QuestionId == r.QuestionId)
                        {
                            r.Question = q;
                        }
                    }
                }
            }
            else if (followUpTypeNum == 60)
            {
                //Retrieve 60 FollowUp Responses
                Responses = _context.Response.Where(r => r.Question.QuestionCategoryId == 4 && r.ApplicationId == applicationId).ToList();
                //Sets all the response.Questions equal to the question
                foreach (var r in Responses)
                {
                    foreach (var q in _context.Question.Where(q => q.QuestionCategoryId == 4).ToList())
                    {
                        if (q.QuestionId == r.QuestionId)
                        {
                            r.Question = q;
                        }
                    }
                }
            }
            else
            {
                //Invalid followUpTypeNum
                return false;
            }
            return true;
        }
    }
}
