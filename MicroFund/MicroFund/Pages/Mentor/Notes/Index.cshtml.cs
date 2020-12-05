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
        public List<MentorAssignment> MentorAssignments { get; set; }
        public List<String> CompanyNames { get; set; }

        public IndexModel(IRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IList<MentorNote> MentorNotes { get;set; }

        public async Task OnGetAsync(int? selected)
        {

            //get current user in order to set updatedby attribute on form
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;
            

            //get all mentor assignments for the current logged in user/mentor
            MentorAssignments = _repository.GetAllMentorAssignmentsByMentorId(CurrentUserId);
            //get a list of all company names assigned to this user/mentor
            CompanyNames = MentorAssignments.Select(x => x.Application.CompanyName).Distinct().ToList();

            //if loading page (null) or selecting All from the dropdown, display all mentor notes
            if (selected == null || selected == -1)
            {
                MentorNotes = await _repository.GetMentorNotes(CurrentUserId, -1);
            }
            else //if company selected
            {
                MentorNotes = await _repository.GetMentorNotes(CurrentUserId, (int)selected);
            }

        }



    }
}
