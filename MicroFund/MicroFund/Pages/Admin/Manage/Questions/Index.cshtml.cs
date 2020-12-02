using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace MicroFund.Pages.Admin.Manage.Questions
{
    public class IndexModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public IndexModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; }
        public IList<QuestionCategory> Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? QuestionCategory)
        {
            Category = await _context.QuestionCategory.ToListAsync(); 

            if (QuestionCategory == null)
            { 
                Question = await _context.Question
                    .Include(q => q.QuestionCategory).ToListAsync();
            }
            else
            {
                Question = await _context.Question
                    .Include(q => q.QuestionCategory).Where(x => x.QuestionCategory.QuestionCategoryId == QuestionCategory).ToListAsync();

            }

            return Page();
        }
    }
}
