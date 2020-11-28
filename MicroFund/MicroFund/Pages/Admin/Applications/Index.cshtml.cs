using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Admin.Applications
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }
        public IList<Application> Applications { get; set; }
        public IList<ApplicationUser> Users { get; set; }

        public IList<ApplicationStatus> Statuses { get; set; } 

        public IList<PitchEvent> PitchEvents { get; set; }
        [BindProperty]
        public int ScheduledPitchEventId { get; set; }
        public void OnGet()
        {
            Applications = _context.Application
                .Include(a => a.ApplicationStatus)
                .AsEnumerable().ToList();
            Users = _context.ApplicationUsers.Where(u => Applications.Select(a => a.ApplicantId).AsEnumerable().ToList().Contains(u.Id)).AsEnumerable().ToList();
            Statuses = _context.ApplicationStatus.AsEnumerable().ToList();
            PitchEvents = _context.PitchEvents.AsEnumerable().ToList();
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

        public IActionResult OnPostSchedulePitch() {

            var pitch = new DataAccessLayer.Models.Pitch();
            var pitch_event = _context.PitchEvents.FirstOrDefault(p => p.PitchEventId == ScheduledPitchEventId);
            pitch.PitchEventId = pitch_event.PitchEventId;
            pitch.ApplicationId = Int32.Parse(Request.Form["applicationId"]);
            pitch.PitchDate = pitch_event.PitchDate;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            pitch.UpdatedBy = claim.Value;
            pitch.UpdatedDate = DateTime.UtcNow;
            pitch.IsArchived = false;
            _context.Pitch.Add(pitch);

            var noti = new Notification();
            var application = _context.Application.FirstOrDefault(a => a.ApplicationId == pitch.ApplicationId);
            noti.UserID = application.ApplicantId;
            noti.NotificationMessage = "You've been scheduled to pitch on: " + pitch.PitchDate.ToShortDateString();
            _context.Notifications.Add(noti);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
