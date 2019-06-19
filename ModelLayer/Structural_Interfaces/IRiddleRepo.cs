using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Structural_Interfaces
{
    public interface IRiddleRepo
    {
        IEnumerable<IRiddle> GetRiddlesByCategory(string _categoryName);
        void PostMessage(string _userID, string _riddleName, string _message);
        IEnumerable<IRiddle> GetUnsolvedRiddles();
    }
}
