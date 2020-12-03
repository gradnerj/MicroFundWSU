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
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MicroFund.Pages.Mentor.Notes
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;
        private readonly IRepository _repository;
        public string CurrentUserId { get; set; }
        public string SelectedCompany { get; set; }

        public IndexModel(IRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IList<MentorNote> MentorNotes { get;set; }

        public async Task OnGetAsync()
        {

            //get current user in order to set updatedby attribute on form
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;
            MentorNotes = await _repository.GetMentorNotes(CurrentUserId);

            //get all mentor assignments for the current logged in user/mentor
            var mentorAssignments = _repository.GetAllMentorAssignmentsByMentorId(CurrentUserId);
            //get a list of all company names assigned to this user/mentor
            var companyNames = mentorAssignments.Select(x => x.Application.CompanyName).Distinct().ToList();
            //create dropdown
            ViewData["CompanyDropDown"] = new SelectList(mentorAssignments, "MentorAssignmentId", "Application.CompanyName");
        }



    }
}
