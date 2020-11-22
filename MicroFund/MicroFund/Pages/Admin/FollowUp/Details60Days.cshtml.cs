using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace MicroFund.Pages.Admin.FollowUp
{
    public class Details60DaysModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Details60DaysModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser ApplicationUser { get; set; }
        public Application Application { get; set; }
        public List<Question> Questions { get; set; }
        public List<Response> ApplicationResponses { get; set; }
        public List<Response> Responses { get; set; }

        public void OnGet(int id)
        {
            Application = _context.Application.FirstOrDefault(a => a.ApplicationId == id);
            ApplicationUser = _context.ApplicationUsers.FirstOrDefault(u => u.Id == Application.ApplicantId);
            Questions = _context.Question.Where(q => q.QuestionCategoryId == 4).ToList();
            Responses = _context.Response.Where(r => r.ApplicationId == id && r.Question.QuestionCategoryId == 4).ToList();
        }
    }
}
