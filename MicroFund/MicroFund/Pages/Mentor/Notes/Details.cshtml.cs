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

            //get current mentor note from database
            MentorNote = _context.MentorNote.Where(x => x.MentorNoteId == id).Include(x => x.MentorAssignment).ThenInclude(x => x.Application).FirstOrDefault();
            //get name of user who last updated object
            UpdatedByName = _repository.GetUserById(MentorNote.UpdatedBy).FullName;

            //if there is a file attached to this note
            if(MentorNote.MentorNoteFileAttachment != null)
            {
                //get the actual file name (sans guid)
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

        /**
         * This helper method returns the file attachment for the given mentor note id
         */
        public IActionResult OnPostDownload(int noteId)
        {
            //get mentor note in question
            MentorNote mentorNote = _context.MentorNote.Where(x => x.MentorNoteId == noteId).FirstOrDefault();
            //get local path
            string webRootPath = _hostingEnvironment.WebRootPath;
            //use helper method to get file byte array
            byte[] fileBytes = GetFile(webRootPath + mentorNote.MentorNoteFileAttachment);
            
            //retrieve original file name to display 
            string filePathOriginal = mentorNote.MentorNoteFileAttachment;
            string[] nameArray = filePathOriginal.Split("$&$%");
            string fileDisplayName = nameArray[1];

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileDisplayName);
        }

        /*
         * This helper method returns the given file path as a file byte array
         */
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
