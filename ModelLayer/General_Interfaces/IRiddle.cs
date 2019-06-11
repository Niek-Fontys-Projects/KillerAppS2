using System.Collections.Generic;

namespace ModelLayer.General_Interfaces
{
    public interface IRiddle
    {
        IUser User { get; }
        string RiddleName { get; }
        string RiddleContent { get; }
        string Answer { get; }
        IEnumerable<ICategory> Categories { get; set; }
        IEnumerable<IMessage> Messages { get; set; }
    }
}
