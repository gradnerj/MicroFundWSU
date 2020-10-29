using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class AuthSenderOptions
    {

        private string user = "WSU Microfund Email Verification";

        private string key = "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";

        public string SendGridUser
        {
            get { return user; }
        }

        public string SendGridKey
        {
            get { return key; }
        }

    }
}
