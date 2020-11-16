using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace MicroFund.Pages.Mentor.Notes
{
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext _context;
        private readonly IRepository _repository;
        [BindProperty]
        public MentorNote MentorNote { get; set; }
        public string UpdatedByName { get; set; }

        public DeleteModel(DataAccessLayer.Data.ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MentorNote = _context.MentorNote.Where(x => x.MentorNoteId == id).Include(x => x.MentorAssignment).ThenInclude(x => x.Application).FirstOrDefault();
            UpdatedByName = _repository.GetUserById(MentorNote.UpdatedBy).FullName;

            if (MentorNote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MentorNote = await _context.MentorNote.FindAsync(id);

            if (MentorNote != null)
            {
                MentorNote.IsArchived = true;
                _context.MentorNote.Update(MentorNote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
