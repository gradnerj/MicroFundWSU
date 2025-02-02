using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Judge.Applications
{
    public class ViewApplicationModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ViewApplicationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public JudgeViewApplicationVM JudgeViewApplicationVM { get; set; }

        public void OnGet(int id)
        {
            var applicationId = id;
            var application = _context.Application.Where(x => x.ApplicationId == applicationId).FirstOrDefault();
            var applicationUser = _context.ApplicationUsers.Where(x => x.Id == application.ApplicantId).FirstOrDefault();
            var responses = _context.Response.Where(x => x.ApplicationId == applicationId).ToList();
            var contactInfos = _context.ContactInfo.Where(x => x.ApplicantId == application.ApplicantId).ToList();

            var questions = new List<Question>();

            foreach (var response in responses)
            {
                var matchedQuestion = _context.Question.Where(x => x.QuestionId == response.QuestionId).FirstOrDefault();
                questions.Add(matchedQuestion);
            }

            JudgeViewApplicationVM = new JudgeViewApplicationVM
            {
                Application = application,
                ApplicationUser = applicationUser,
                Responses = responses,
                Questions = questions,
                ContactInfos = contactInfos
            };
}
    }
}
