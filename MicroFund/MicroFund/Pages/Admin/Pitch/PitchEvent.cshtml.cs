using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroFund.Pages.Admin.Pitch
{
    public class PitchEventModel : PageModel
    {
        [BindProperty]
        public int PitchId { get; set; }
        public void OnGet(int pitchId)
        {
            PitchId = pitchId;
        }
    }
}
