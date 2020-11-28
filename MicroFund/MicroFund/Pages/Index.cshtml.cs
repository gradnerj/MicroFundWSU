using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MicroFund.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
            
        }

        public IActionResult OnGet()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            } else
            {
                if (User.IsInRole(Utility.StaticDetails.MentorRole)) {
                    return RedirectToPage("/Mentor/Dashboard/Index");
                }
                else if (User.IsInRole(Utility.StaticDetails.JudgeRole)) {
                    return RedirectToPage("/Judge/Dashboard/Index");
                }
                else if (User.IsInRole(Utility.StaticDetails.AdminRole)) {

                    //return RedirectToPage("/Calendar");
                    return RedirectToPage("/Admin/Dashboard/Index");
                }
                else
                {
                    return Page();
                }
                
            }
            
        } 

        
    }
}
