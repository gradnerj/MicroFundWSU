using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Admin.Applications
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) {
            _context = context;
        }
        public IList<Application> Applications { get; set; }
        public IList<ApplicationUser> Users { get; set; }

        public IList<ApplicationStatus> Statuses { get; set; } 
        public void OnGet()
        {
            Applications = _context.Application
                .Include(a => a.ApplicationStatus)
                .AsEnumerable().ToList();
            Users = _context.ApplicationUsers.Where(u => Applications.Select(a => a.ApplicantId).AsEnumerable().ToList().Contains(u.Id)).AsEnumerable().ToList();
            Statuses = _context.ApplicationStatus.AsEnumerable().ToList();
        }

        public IActionResult OnPost() {
            var appId = Request.Form["applicationId"];
            var statusid = Request.Form["statusid"];
            var application = _context.Application.FirstOrDefault(a => a.ApplicationId == Int32.Parse(appId));
            application.ApplicationStatusId = Int32.Parse(statusid);
            _context.Update(application);

            var applicantId = _context.Application.FirstOrDefault(a => a.ApplicationId == Int32.Parse(appId)).ApplicantId;
            var notification = new Notification();
            notification.UserID = applicantId;
            notification.NotificationMessage = "New Application Status: " + _context.ApplicationStatus.FirstOrDefault(s => s.ApplicationStatusId == Int32.Parse(statusid)).StatusDescription;
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
