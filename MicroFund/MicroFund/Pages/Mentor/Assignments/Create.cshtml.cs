﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace MicroFund.Pages.Mentor.Assignments
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;

        public CreateModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationId"] = new SelectList(_context.Application, "ApplicationId", "ApplicantId");
        ViewData["MentorId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MentorAssignment MentorAssignment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MentorAssignment.Add(MentorAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
