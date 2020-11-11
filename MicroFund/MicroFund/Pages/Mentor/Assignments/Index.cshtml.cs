using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Mentor.Assignments
{
    public class IndexModel : PageModel
    {

        private readonly IRepository _repository;
        private readonly ApplicationDbContext _context;
        public IList<IdentityUser> Mentors { get; set; }
        public Dictionary<string, string> MentorAssignments { get; set; }
        public IList<Application> Applications { get; set; }


        public IndexModel(IRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            MentorAssignments = new Dictionary<string, string>();
            Mentors = await _repository.GetAllMentorsAsync();
            MentorAssignments = await _repository.GetAllMentorAssignmentsAsync();
            Applications = await _repository.GetAllApplicationsAsync();
        }
    }
}
