using System;

namespace ModelLayer.General_Interfaces
{
    public interface IMessage
    {
        string UserName { get; }
        string MessageContent { get; }
        string Time { get; }
    }
}
