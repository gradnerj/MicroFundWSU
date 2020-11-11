using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MicroFund.Pages.Admin.Manage.ApplicationStatus
{
    public class UpsertModel : PageModel
    {

        private readonly IRepository _repository;
        private readonly ApplicationDbContext _context;
        public string CurrentUserId;

        public UpsertModel(IRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;            
        }

        [BindProperty]
        public DataAccessLayer.Models.ApplicationStatus ApplicationStatusObj { get; set; }


        public IActionResult OnGet(int? id)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            ApplicationStatusObj = new DataAccessLayer.Models.ApplicationStatus();
            
            if(id != null)
            {
                ApplicationStatusObj = _repository.GetApplicationStatusObjById(id);
                if (ApplicationStatusObj == null)
                {
                    return NotFound();
                }
            }          

            return Page();

        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ApplicationStatusObj.ApplicationStatusId == 0)
            {
                _context.ApplicationStatus.Add(ApplicationStatusObj);
            } else
            {
                _context.ApplicationStatus.Update(ApplicationStatusObj);
            }

            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
