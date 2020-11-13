using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Security.Claims;

namespace MicroFund.Pages.Mentor.Assignments
{
    public class EditModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;
        private readonly IRepository _repository;
        public Application Application { get; set; }
        public ApplicationUser Mentor { get; set; }
        public string CurrentUserId { get; set; }
        public int Iteration { get; set; }

        public EditModel(DataAccessLayer.Data.ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [BindProperty]
        public MentorAssignment MentorAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //get current user in order to set updatedby attribute on form
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            //set application object
            Application = _repository.GetApplicationById(id);
            //set mentor object
            Mentor = _repository.GetMentorByApplicationId(id);
            //get application number of application and business
            Iteration = await _repository.GetIterationByApplicantId(Application.ApplicationId, Application.ApplicantId);            

            if(Mentor != null)
            {
                MentorAssignment = await _context.MentorAssignment
               .Include(m => m.Application)
               .Include(m => m.Mentor).FirstOrDefaultAsync(m => m.MentorAssignmentId == id);
            }          

           ViewData["MentorId"] = new SelectList(await _repository.GetAllMentorsAsync(), "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {                      
            //if editing existing assignment
            if(MentorAssignment.MentorAssignmentId > 0)
            {
                //get application
                MentorAssignment.Application = _repository.GetApplicationById(MentorAssignment.ApplicationId);

                //update status ONLY IF current status is Approved to avoid regressing status of application in later stages
                if(MentorAssignment.Application.ApplicationStatusId == _repository.GetStatusIdByName("Approved"))
                {
                    MentorAssignment.Application.ApplicationStatusId = _repository.GetStatusIdByName("Assigned to Mentor");                    
                }
                _context.Attach(MentorAssignment).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorAssignmentExists(MentorAssignment.MentorAssignmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            } else //if adding new assignment
            {
                //get application in order to update status
                MentorAssignment.Application = _repository.GetApplicationById(MentorAssignment.ApplicationId);
                //update status
                MentorAssignment.Application.ApplicationStatusId = _repository.GetStatusIdByName("Assigned to Mentor");
                _context.MentorAssignment.Add(MentorAssignment);
                await _context.SaveChangesAsync();

            }
            return RedirectToPage("./Index");
        }

        private bool MentorAssignmentExists(int id)
        {
            return _context.MentorAssignment.Any(e => e.MentorAssignmentId == id);
        }
    }
}
