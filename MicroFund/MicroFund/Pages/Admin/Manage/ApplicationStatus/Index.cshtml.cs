using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MicroFund.Pages.Admin.Manage.ApplicationStatus
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;
        private readonly ApplicationDbContext _context;
        public IList<DataAccessLayer.Models.ApplicationStatus> ApplicationStatuses { get; set; }

        public IndexModel(IRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            
            ApplicationStatuses = await _repository.GetApplicationStatuses();
        }

    }
}
