using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IUser
    {
        string UserName { get; }
        string Email { get; }
    }
}
