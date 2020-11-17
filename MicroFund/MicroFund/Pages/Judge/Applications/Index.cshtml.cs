using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using DataAccessLayer.Models.ViewModels;

namespace MicroFund.Pages.Judge.Applications
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;

        public IndexModel(IRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public JudgeReviewApplicationsVM JudgeReviewApplicationsVM { get; set; }

        public async Task OnGetAsync()
        {
            JudgeReviewApplicationsVM = new JudgeReviewApplicationsVM
            {
                ApplicationUsers = await _repository.GetAllUsersAsync(),
                Applications = await _repository.GetAllApplicationsAsync()
            };
        }
    }
}
