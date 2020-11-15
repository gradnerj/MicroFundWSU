using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Admin.Pitch
{
    public class PitchEventModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public PitchEventModel(ApplicationDbContext context) {
            _context = context;
        }

        [BindProperty]
        public PitchEvent PitchEvent{ get; set; }
        [BindProperty]
        public IEnumerable<DataAccessLayer.Models.Pitch> Pitches { get; set; }

        public IQueryable<ApplicationUser> Applicants { get; set; }
        public void OnGet(int pitchEventId)
        {
            PitchEvent = _context.PitchEvents.FirstOrDefault(p => p.PitchId == pitchEventId);
            var pitchEventDate = PitchEvent.PitchDate;
            Pitches = _context.Pitch.Where(p => p.PitchDate == pitchEventDate)
                .Include(a => a.Application)
                .ToList().AsEnumerable();
            
            List<string> userIds = new List<string>();
            foreach(var p in Pitches) {
                userIds.Add(_context.ApplicationUsers.FirstOrDefault(u => u.Id == p.Application.ApplicantId).Id);
            }
            Applicants = _context.ApplicationUsers.Where(u => userIds.Contains(u.Id));
        }
    }
}
