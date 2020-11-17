using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.ViewModels
{
    public class JudgeViewApplicationVM
    {
        public Application Application { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Response> Responses { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<ContactInfo> ContactInfos { get; set; }

    }
}
