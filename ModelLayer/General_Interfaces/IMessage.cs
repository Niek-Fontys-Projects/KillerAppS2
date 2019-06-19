using System;

namespace ModelLayer.General_Interfaces
{
    public interface IMessage
    {
        IUser User { get; }
        string MessageContent { get; }
        string Time { get; }
    }
}
