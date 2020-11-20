using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.ViewModels;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MicroFund.Pages.Judge.Scorecards
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;
        private readonly IEmailSender _util;
        public IndexModel(IRepository repository, ApplicationDbContext context, IEmailSender util)
        {
            _repository = repository;
            _context = context;
            _util = util; 
        }
        private string log = "gradnerj@gmail.com";
        public JudgeViewPitchesVM JudgeViewPitchesVM { get; set; }
        
        public async Task OnGetAsync()
        {
            await _util.SendEmailAsync(log, "MF Judge scorecard", "js");
            JudgeViewPitchesVM = new JudgeViewPitchesVM
            {
                PitchEvents = await _repository.GetAllPitchEventsAsync(),
                Pitches = _context.Pitch.Include(a => a.Application).ToList().AsEnumerable(),
                ApplicationUsers = await _repository.GetAllUsersAsync()
            };
        }
    }
}
