using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IMessage
    {
        string UserName { get; }
        string RiddleName { get; }
        string Message { get; }
        DateTime Time { get; }
    }
}
