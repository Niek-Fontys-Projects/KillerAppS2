using System;

namespace ModelLayer.General_Interfaces
{
    public interface IMessage
    {
        IUser User { get; set;  }
        string MessageContent { get; }
        string Time { get; }
    }
}
