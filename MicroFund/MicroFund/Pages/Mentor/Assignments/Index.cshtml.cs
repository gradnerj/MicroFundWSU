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
using Microsoft.AspNetCore.Identity;

namespace MicroFund.Pages.Mentor.Assignments
{
    public class IndexModel : PageModel
    {

        private readonly IRepository _repository;
        public IList<IdentityUser> Mentors { get; set; }
        public Dictionary<string, string> MentorAssignments { get; set; }
        public IList<Application> Applications { get; set; }
        public int Iteration { get; set; }
        public Dictionary<int, int> ApplicationIterations { get; set; }


        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            MentorAssignments = new Dictionary<string, string>();
            ApplicationIterations = new Dictionary<int, int>();
            
            Mentors = await _repository.GetAllMentorsAsync();
            MentorAssignments = await _repository.GetAllMentorAssignmentsAsync();
            Applications = await _repository.GetAllApplicationsToAssignAsync();
            ApplicationIterations = await _repository.GetAllApplicationIterationsAsync();
        }
    }
}
