using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IAnswerSuggestion
    {
        string UserName { get; }
        string RiddleName { get; }
        string Answer { get; }
    }
}
