using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Security.Claims;

namespace MicroFund.Pages.Mentor.Notes
{
    public class IndexModel : PageModel
    {
        
        private readonly IRepository _repository;
        public string CurrentUserId { get; set; }

        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public IList<MentorNote> MentorNote { get;set; }

        public async Task OnGetAsync()
        {

            //get current user in order to set updatedby attribute on form
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = claim.Value;
            MentorNote = await _repository.GetMentorNotes(CurrentUserId);
        }
    }
}
