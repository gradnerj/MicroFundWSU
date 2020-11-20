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
