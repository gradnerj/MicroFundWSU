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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MicroFund.Pages.Mentor.Notes
{
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext _context;
        private readonly IRepository _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MentorNote MentorNote { get; set; }
        public string UpdatedByName { get; set; }
        public string FileName { get; set; }

        public DetailsModel(DataAccessLayer.Data.ApplicationDbContext context, IRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MentorNote = _context.MentorNote.Where(x => x.MentorNoteId == id).Include(x => x.MentorAssignment).ThenInclude(x => x.Application).FirstOrDefault();
            UpdatedByName = _repository.GetUserById(MentorNote.UpdatedBy).FullName;

            if(MentorNote.MentorNoteFileAttachment != null)
            {
                string fullName = MentorNote.MentorNoteFileAttachment;
                string[] nameArray = fullName.Split("$&$%");
                FileName = nameArray[1];
            }

            if (MentorNote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostDownload(int noteId)
        {
            MentorNote mentorNote = _context.MentorNote.Where(x => x.MentorNoteId == noteId).FirstOrDefault();
            string webRootPath = _hostingEnvironment.WebRootPath;
            byte[] fileBytes = GetFile(webRootPath + mentorNote.MentorNoteFileAttachment);
            string filePathOriginal = mentorNote.MentorNoteFileAttachment;
            string[] nameArray = filePathOriginal.Split("$&$%");
            string fileDisplayName = nameArray[1];

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileDisplayName);
        }

        private byte[] GetFile(string s)
        {
            FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if(br != fs.Length)
            {
                throw new IOException(s);
            }
            return data;
        }
    }
}
