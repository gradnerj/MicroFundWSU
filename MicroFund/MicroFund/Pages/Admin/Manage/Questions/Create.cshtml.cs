using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System.Security.Claims;

namespace MicroFund.Pages.Admin.Manage.Questions
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;
        public string CurrentUserId;

        public CreateModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["QuestionCategoryId"] = new SelectList(_context.QuestionCategory, "QuestionCategoryId", "QuestionCategoryDescription");
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Question.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
