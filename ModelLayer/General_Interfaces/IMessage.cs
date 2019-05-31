using System;

namespace ModelLayer.General_Interfaces
{
    public interface IMessage
    {
        string UserName { get; }
        string Message { get; }
        DateTime Time { get; }
    }
}
