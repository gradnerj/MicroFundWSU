using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Utility;
using System.Web;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Repository;

namespace MicroFund.Pages.Applicant.Apply
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IEmailSender _util;
        private readonly IRepository _repo;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public InputModel Input { get; set; }
        public ApplicationUser Applicant { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Application Application { get; set; }

        public IndexModel(ApplicationDbContext context, 
            IEmailSender util, 
            IWebHostEnvironment hostingEnvironment,
            IRepository repo,
            UserManager<IdentityUser> userManager) {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _util = util;
            _userManager = userManager;
            _repo = repo;
        }

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login");
            }
            else
            {
                if (!User.IsInRole(StaticDetails.ApplicantRole) && User.IsInRole(StaticDetails.JudgeRole))
                {
                    return RedirectToPage("/Judge/Dashboard");
                }
                if (!User.IsInRole(StaticDetails.ApplicantRole) && User.IsInRole(StaticDetails.MentorRole))
                {
                    return RedirectToPage("/Mentor/Dashboard");
                }
                else
                {
                    var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                    if (claim.Value == null)
                    {
                        return RedirectToPage("/Account/Login");
                    }

                    Applicant = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == claim.Value);
                    ContactInfo = await _context.ContactInfo.FirstOrDefaultAsync(c => c.ApplicantId == claim.Value);
                    await _util.SendEmailAsync(StaticDetails.Log, "MF Apply Get", "apply");
                    //if id is not null updating a previous application
                    if (id != null)
                    {
                        Application = await _context.Application
                            .Include(a => a.ApplicationStatus)
                            .Include(a => a.Responses)
                                .ThenInclude(r => r.Question)
                            .FirstOrDefaultAsync(a => a.ApplicationId == id);
                        Input = new InputModel(
                            Application.ApplicationId,
                            Application.CompanyName,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 1).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 2).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 3).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 4).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 5).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 6).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 7).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 8).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 9).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 10).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 11).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 12).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 13).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 14).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 15).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 16).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 17).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 18).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 19).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 20).ResponseDescription,
                            Application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 21).ResponseDescription
                            );
                        if(Application.ApplicationStatus.StatusDescription != "In Remediation")
                        {
                            Input.IsSubmittable = false;
                        }
                        else
                        {
                            Input.IsSubmittable = true;
                        }
                    }
                    else
                    {
                        Input = new InputModel
                        {
                            YesNoGeneratedSales = "No",
                            YesNoHasCompanyWebsite = "No",
                            YesNoHasPrototype = "No",
                            YesNoHasIntelProp = "No",
                            YesNoExternalFunding = "No",
                            YesNoSmallDevCounselor = "No",
                            StatusOfBusiness = "My company/service is still a concept.",
                            StartedDate = Convert.ToDateTime("1/1/0001 12:00:00 AM"),
                            SalesDescription = "I have not generated any sales.",
                            WebsiteUrl = "I do not have a website.",
                            PrototypeFile = "I do not have a prototype.",
                            IntelPropDesc = "I do not have any intellectual property.",
                            HasExternalFunding = "I have not received any external funding.",
                            SmallBusinessDevCenterCounselorDesc = "I have not met with a Small Business Development Center Counselor.",
                            PreviousMicroFundRecipient = "No, I Have not previously received a Wildcat Micro Fund grant.",
                            HaveAttendedMFWorkshop = "No, I Have not attended a Wildcat Micro Fund Workshop.",
                            OneMillionCupsExp = "No, I Have not attended, applied to present, or presented at 1 Million Cups.",
                            IsSubmittable = true
                        };
                    }
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            await _util.SendEmailAsync(StaticDetails.Log, "MF Apply Post", "apply");

            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var adminIds = admins.Select(a => a.Id).ToList();
            foreach(var aId in adminIds) {
                var noti = new Notification();
                noti.NotificationMessage = "New Application for" + Input.CompanyName;
                noti.UserID = aId;
                _context.Notifications.Add(noti);
            }
            _context.SaveChanges();

            if (claim.Value == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!ModelState.IsValid)
            {
                Applicant = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == claim.Value);
                ContactInfo = await _context.ContactInfo.FirstOrDefaultAsync(c => c.ApplicantId == claim.Value);
       
                return Page();
            }

            var questions = await _context.Question
                        .Where(q => q.QuestionCategory.QuestionCategoryDescription == "Application Questions")
                        .OrderBy(q => q.QuestionNumber)
                        .ToListAsync();

            if (questions == null)
            {
                return NotFound();
            }

            var application = new Application();
               
            if(Input.ApplicationId == 0)
            {
                application.ApplicationCreationDate = DateTime.Now;
                application.ApplicantId = claim.Value;
                application.UpdatedBy = claim.Value;
                application.UpdatedDate = DateTime.Now;
                application.CompanyName = Input.CompanyName;
                application.ApplicationStatus = await _context.ApplicationStatus.FirstOrDefaultAsync(s => s.StatusDescription == "In Review");
                
                _context.Application.Add(application);
                await _context.SaveChangesAsync();

                application.Responses = new List<Response>();
                
                foreach(var question in questions)
                {
                    var response = new Response();
                    response.Application = application;
                    response.Question = question;
                    response.UpdatedBy = claim.Value;
                    response.UpdatedDate = DateTime.Now;
                    application.Responses.Add(response);
                }
            }
            else
            {
                application = await _context.Application
                    .Include(a => a.Responses)
                    .FirstOrDefaultAsync(a => a.ApplicationId == Input.ApplicationId);
                application.CompanyName = Input.CompanyName;
                application.UpdatedBy = claim.Value;
                application.UpdatedDate = DateTime.Now;
                
                foreach (var response in application.Responses)
                {
                    response.UpdatedBy = claim.Value;
                    response.UpdatedDate = DateTime.Now;
                }

                
            }

            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 1).ResponseDescription = Input.ProductServiceDescription;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 2).ResponseDescription = Input.StatusOfBusiness;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 3).ResponseDescription = Input.StartedDate.ToString();
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 4).ResponseDescription = Input.SalesDescription;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 5).ResponseDescription = Input.Industry;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 6).ResponseDescription = Input.WebsiteUrl;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 7).ResponseDescription = Input.PrototypeFile;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 8).ResponseDescription = Input.IntelPropDesc;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 9).ResponseDescription = Input.MarketOpportunity;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 10).ResponseDescription = Input.TargetMarketDemographic;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 11).ResponseDescription = Input.ProjectedSalesDesc;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 12).ResponseDescription = Input.CompetitionDesc;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 13).ResponseDescription = Input.TeamDesc;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 14).ResponseDescription = Input.AmountRequested;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 15).ResponseDescription = Input.PlanForFunds;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 16).ResponseDescription = Input.PreviousMicroFundRecipient;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 17).ResponseDescription = Input.HasExternalFunding;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 18).ResponseDescription = Input.HearAboutMicroFund;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 19).ResponseDescription = Input.HaveAttendedMFWorkshop;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 20).ResponseDescription = Input.OneMillionCupsExp;
            application.Responses.FirstOrDefault(r => r.Question.QuestionNumber == 21).ResponseDescription = Input.SmallBusinessDevCenterCounselorDesc;
            
            foreach(var a in admins)
            {
                await _util.SendEmailAsync(a.Email, "New MicroFund Application", application.CompanyName + " has just applied!");
            }
            


            _context.Application.Update(application);
            await _context.SaveChangesAsync();

            return RedirectToPage("./");
        }
        

        public class InputModel
        {
            public InputModel()
            {

            }
            public InputModel(int id, string companyName, string productdesc, string businessStatus, string dateStarted, string salesdesc, string industry,
                 string websiteUrl, string prototype, string intelProp, string marketOpp, string targetMarket, string projectedSales,
                 string competionDesc, string teamDesc, string amountRequested, string planForFunds, string preRecipient, string externalFunds,
                 string heardOfMF, string attendedMFW, string oneMilCups, string smallDevCounselor)
            {
                ApplicationId = id;
                CompanyName = companyName; 
                ProductServiceDescription = productdesc;
                StatusOfBusiness = businessStatus;
                StartedDate = Convert.ToDateTime(dateStarted);
                SalesDescription = salesdesc;
                Industry = industry;
                WebsiteUrl = websiteUrl;
                PrototypeFile = prototype;
                IntelPropDesc = intelProp;
                MarketOpportunity = marketOpp;
                TargetMarketDemographic = targetMarket;
                ProjectedSalesDesc = projectedSales;
                CompetitionDesc = competionDesc;
                TeamDesc = teamDesc;
                AmountRequested = amountRequested;
                PlanForFunds = planForFunds;
                PreviousMicroFundRecipient = preRecipient;
                HasExternalFunding = externalFunds;
                HearAboutMicroFund = heardOfMF;
                HaveAttendedMFWorkshop = attendedMFW;
                OneMillionCupsExp = oneMilCups;
                SmallBusinessDevCenterCounselorDesc = smallDevCounselor;

                if(salesdesc == "I have not generated any sales.")
                {
                    YesNoGeneratedSales = "No";
                }
                else
                {
                    YesNoGeneratedSales = "Yes";
                }

                if(websiteUrl == "I do not have a website.")
                {
                    YesNoHasCompanyWebsite = "No";
                }
                else
                {
                    YesNoHasCompanyWebsite = "Yes";
                }

                if(prototype == "I do not have a prototype.")
                {
                    YesNoHasPrototype = "No";
                }
                else
                {
                    YesNoHasPrototype = "Yes";
                }

                if(intelProp == "I do not have any intellectual property.")
                {
                    YesNoHasIntelProp = "No";
                }
                else
                {
                    YesNoHasIntelProp = "Yes";
                }

                if(externalFunds == "I have not received any external funding.")
                {
                    YesNoExternalFunding = "No";
                }
                else
                {
                    YesNoExternalFunding = "Yes";
                }

                if(smallDevCounselor == "I have not met with a Small Business Development Center Counselor.")
                {
                    YesNoSmallDevCounselor = "No";
                }
                else
                {
                    YesNoSmallDevCounselor = "Yes";
                }
            }
            public int ApplicationId { get; set; }
            
            [Required(ErrorMessage = "Company name is required.")]
            public string CompanyName { get; set; }

            [Required(ErrorMessage = "Product service description is required.")]
            public string ProductServiceDescription { get; set; }

            [Required(ErrorMessage = "Please select the status of your company.")]
            public string StatusOfBusiness { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime StartedDate { get; set; }

            [Required(ErrorMessage = "Sales description is required.")]
            public string SalesDescription { get; set; }

            [Required(ErrorMessage = "Please select which industry your company/service is in.")]
            public string Industry { get; set; }
           
            [Required(ErrorMessage = "Website url is required.")]
            public string WebsiteUrl { get; set; }

            [Required]
            public string PrototypeFile { get; set; }

            [Required(ErrorMessage = "Intellectual property description is required.")]
            public string IntelPropDesc { get; set; }

            [Required(ErrorMessage = "Market opportunity is required.")]
            [StringLength(750)]
            public string MarketOpportunity { get; set; }

            [Required(ErrorMessage = "Target market demographic is required.")]
            [StringLength(750)]
            public string TargetMarketDemographic { get; set; }

            [Required(ErrorMessage = "Projeted sales description is required.")]
            [StringLength(750)]
            public string ProjectedSalesDesc { get; set; }

            [Required(ErrorMessage = "Competition description is required.")]
            [StringLength(750)]
            public string CompetitionDesc { get; set; }

            [Required(ErrorMessage = "Team description is required.")]
            [StringLength(750)]
            public string TeamDesc { get; set; }

            [Required]
            [RegularExpression("^[0-9]*", ErrorMessage = "Invalid input, please enter numbers only.")]
            public string AmountRequested { get; set; }

            [Required(ErrorMessage = "Plans for funds is required.")]
            public string PlanForFunds { get; set; }

            [Required]
            public string PreviousMicroFundRecipient { get; set; }

            [Required]
            public string HasExternalFunding { get; set; }

            [Required(ErrorMessage = "Please select an option for how you heard of Microfund.")]
            public string HearAboutMicroFund { get; set; }

            [Required]
            public string HaveAttendedMFWorkshop { get; set; }

            [Required]
            public string OneMillionCupsExp { get; set; }

            [Required(ErrorMessage = "Please select the location of your meeting.")]
            public string SmallBusinessDevCenterCounselorDesc { get; set; }

            /**
             * these properties are only used for yes/no radio buttons
             * they are not responses saved to the application
             */
            public string YesNoGeneratedSales { get; set; }
            public string YesNoHasCompanyWebsite { get; set; }
            public string YesNoHasPrototype { get; set; }
            public string YesNoHasIntelProp { get; set; }
            public string YesNoExternalFunding { get; set; }
            public string YesNoSmallDevCounselor { get; set; }
            public bool IsSubmittable { get; set; }


        }
    }
}
