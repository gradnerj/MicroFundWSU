using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models.ViewModels;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Judge.Applications
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;

        public IndexModel(IRepository repository)
        {
            _repository = repository;
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

