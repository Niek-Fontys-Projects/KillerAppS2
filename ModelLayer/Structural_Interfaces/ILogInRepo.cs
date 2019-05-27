using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Structural_Interfaces
{
    public interface ILogInRepo
    {
        IUserWithPassWord GetUserByUserName(string _userName);
    }
}
