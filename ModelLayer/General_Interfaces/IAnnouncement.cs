using System;

namespace ModelLayer.General_Interfaces
{
    public interface IAnnouncement
    {
        string Topic { get; }
        string Content { get; }
        DateTime Date { get; }
    }
}
