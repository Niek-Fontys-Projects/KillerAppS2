using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IUserWithPassWord : IUser
    {
        string PassWord { get; }
        string PassWordHash { get; }
    }
}
