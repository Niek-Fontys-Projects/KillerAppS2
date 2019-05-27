using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Structural_Interfaces
{
    public interface ILogInValidator
    {
        bool ValidateUser(string _userName, string _passWord, IUserWithPassWord _user);
    }
}
