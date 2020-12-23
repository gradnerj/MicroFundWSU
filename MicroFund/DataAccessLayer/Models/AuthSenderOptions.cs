using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class AuthSenderOptions
    {

        private string user = "WSU Microfund Email Verification";

        private string key = "";

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
