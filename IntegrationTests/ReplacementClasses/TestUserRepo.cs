using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.ReplacementClasses
{
    public class TestUserRepo : IUserRepo
    {
        private string userName;
        private string mail;
        private string passWord;
        private string passWordhash;
        public bool AddUser(string _userName, string _mail, string _passWord, string _passWordhash)
        {
            userName = _userName;
            mail = _mail;
            passWord = _passWord;
            passWordhash = _passWordhash;
            return true;
        }

        public IUserWithPassWord GetUserByUserName(string _userName)
        {
            return new User() { UserName = userName, Email = mail, PassWord = passWord, PassWordHash = passWordhash, UserID = "ID" };
        }
    }
}
