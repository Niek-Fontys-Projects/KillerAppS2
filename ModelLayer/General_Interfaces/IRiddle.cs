using System.Collections.Generic;

namespace ModelLayer.General_Interfaces
{
    public interface IRiddle
    {
        string UserName { get; }
        string RiddleName { get; }
        string RiddleContent { get; }
        string Answer { get; }
        IEnumerable<ICategory> Categories { get; set; }
    }
}
