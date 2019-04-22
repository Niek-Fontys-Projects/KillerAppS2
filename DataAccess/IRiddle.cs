using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    interface IRiddle
    {
        string UserName { get; }
        string RiddleName { get; }
        string RiddleContent { get; }
        string Answer { get; }
        IEnumerable<ICategory> Categories { get; }
    }
}
