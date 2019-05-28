using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.LogInValidator
{
    public class Validator : ILogInValidator
    {
        public Validator()
        {

        }

        public LogInResult ValidateUser(string _userName, string _passWord, IUserWithPassWord _user)
        {
            if(_user == null)
            {
                return LogInResult.UserName;
            }
            if(_passWord != _user.PassWord)
            {
                return LogInResult.PassWord;
            }
            return LogInResult.Good;
        }
    }
}
