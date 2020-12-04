using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Admin.Pitch
{
    public class EditPitchModel : PageModel
    {
        private readonly DataAccessLayer.Data.ApplicationDbContext _context;
        public string CurrentUserId;
        public EditPitchModel(DataAccessLayer.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public int ID { get; set; }

        public AwardHistory SelectedAward { get; set; }
        public int PitchId { get; set; }
        public IActionResult OnGet(int id, int SelectedPitch)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;

            PitchId = SelectedPitch;

            IQueryable<AwardHistory> AwardHistory = _context.AwardHistory.Where(a => a.AwardHistoryId == id);

            SelectedAward = AwardHistory.FirstOrDefault();

            if (SelectedAward == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var CashAmount = Request.Form["CashAmount"];
            var ServicesAmount = Request.Form["ServicesAmount"];
            var AwardHistoryId = Request.Form["AwardHistoryId"];
            var ID = Request.Form["PitchId"];

            int id = Convert.ToInt32(AwardHistoryId);

            IQueryable<AwardHistory> AwardHistory = _context.AwardHistory.Where(a => a.AwardHistoryId == id);

            SelectedAward = AwardHistory.FirstOrDefault();

            SelectedAward.CashAmount = Convert.ToInt32(CashAmount);
            SelectedAward.ServicesAmount = Convert.ToInt32(ServicesAmount);
            SelectedAward.UpdatedDate = DateTime.Now;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;
            SelectedAward.UpdatedBy = CurrentUserId;

            //https://localhost:44357/Admin/Pitch/AwardPitch?pitchId=3
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SelectedAward).State = EntityState.Modified;
            */
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectedAwardExists(SelectedAward.AwardHistoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./AwardPitch", new { PitchId = Convert.ToInt32(ID) });
        }
        private bool SelectedAwardExists(int id)
        {
            return _context.AwardHistory.Any(e => e.AwardHistoryId == id);
        }
    }
}
