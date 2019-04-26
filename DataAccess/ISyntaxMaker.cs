using ModelLayer.General_Interfaces;
using System;

namespace DataAccess
{
    internal interface ISyntaxMaker
    {
        string InsertPreFix(string _query, Type _type);
        string Insert(IAnnouncement _announcement);
        string Insert(IUserWithPassWord _user);
        string Insert(IRating _rating);
        string Insert(IMessage _message);
        string Insert(IAnswerSuggestion _answerSuggestion);
        string Insert(IRiddle _riddle);
    }
}
