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

        public async Task<IActionResult> OnGetAsync(int appId)
        {
            //get current user in order to set updatedby attribute on form
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            //get application
            Application = _repository.GetApplicationById(appId);
            //get mentor
            Mentor = _repository.GetMentorByApplicationId(appId);
            //get application iteration number
            Iteration = await _repository.GetIteration(Application.ApplicationId, Application.ApplicantId, Application.CompanyName);            

            if(Mentor != null)
            {
                MentorAssignment = await _context.MentorAssignment
               .Include(m => m.Application)
               .Include(m => m.Mentor).FirstOrDefaultAsync(m => m.ApplicationId == appId);
            }else
            {
                MentorAssignment = new MentorAssignment();
            }         

           ViewData["MentorId"] = new SelectList(await _repository.GetAllMentorsAsync(), "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if updating mentor
            if(MentorAssignment.MentorAssignmentId > 0)
            {
                //get application
                MentorAssignment.Application = _repository.GetApplicationById(MentorAssignment.ApplicationId);

                //update status only if current status is Approved to avoid regressing status of application in later stages
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

            } else //if first time adding mentor
            {
                //get application
                MentorAssignment.Application = _repository.GetApplicationById(MentorAssignment.ApplicationId);
                //update status
                MentorAssignment.Application.ApplicationStatusId = _repository.GetStatusIdByName("Assigned to Mentor");
                _context.MentorAssignment.Add(MentorAssignment);
                await _context.SaveChangesAsync();

            }

            var noti = new Notification();
            noti.UserID = MentorAssignment.MentorId;
            noti.NotificationMessage = "New assignment: " + MentorAssignment.Application.CompanyName;
            _context.Notifications.Add(noti);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

        private bool MentorAssignmentExists(int id)
        {
            return _context.MentorAssignment.Any(e => e.MentorAssignmentId == id);
        }
    }
}
