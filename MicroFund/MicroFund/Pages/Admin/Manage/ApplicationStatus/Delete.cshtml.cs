using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Admin.Manage.ApplicationStatus
{
    public class DeleteModel : PageModel
    {
        private IRepository _repo;
        private ApplicationDbContext _context;
        public DeleteModel(IRepository repo, ApplicationDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        [BindProperty]
        public DataAccessLayer.Models.ApplicationStatus ApplicationStatusObj { get; set; }
        
        public void OnGet(int? id)
        {
            ApplicationStatusObj = _repo.GetApplicationStatusObjById(id);

        }

        public IActionResult OnPost()
        {
            var status = _context.ApplicationStatus.Where(x => x.ApplicationStatusId == ApplicationStatusObj.ApplicationStatusId).FirstOrDefault();
            status.IsArchived = true;
            _context.ApplicationStatus.Update(status);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
