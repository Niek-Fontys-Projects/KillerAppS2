using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.General_Models
{
    public class User : IUserWithPassWord
    {
        private string userName;
        private string eMail;
        private string passWord;
        private string passWordhash;

        public User()
        {
            userName = string.Empty;
            eMail = string.Empty;
            passWord = string.Empty;
            passWordhash = string.Empty;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Email
        {
            get { return eMail; }
            set { eMail = value; }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public string PassWordHash
        {
            get { return passWordhash; }
            set { passWordhash = value; }
        }
    }
}
