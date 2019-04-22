using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IAnnouncement
    {
        string Topic { get; }
        string Content { get; }
        DateTime Date { get; }
    }
}
