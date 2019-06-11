using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Structural_Interfaces
{
    public enum LogInResult
    {
        Good,
        UserName,
        PassWord
    }
    public interface IUserValidator
    {
        LogInResult ValidateUser(string _passWord, IUserWithPassWord _user);
        bool ValidateEMailAddress(string _email);
    }
}
