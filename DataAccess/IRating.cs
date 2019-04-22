using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IRating
    {
        string UserName { get; }
        string RiddleName { get; }
        int Score { get; }
    }
}
