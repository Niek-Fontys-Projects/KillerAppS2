using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Structural_Interfaces
{
    public interface IUserRepo
    {
        IUserWithPassWord GetUserByUserName(string _userName);
        void AddUser(string _userName, string _mail, string _passWord, string _PassWordhash);
    }
}
