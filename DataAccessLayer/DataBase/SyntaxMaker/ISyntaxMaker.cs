using ModelLayer.General_Interfaces;
using System;

namespace DataLayer.DataBase.SyntaxMaker
{
    internal interface ISyntaxMaker
    {
        string Insert(Type _type, string _params);
        string StoredProcedure(string _procedureName, string _params);
        string ToParameter(string _parameterString, object _objectToBeParameterized);
    }
}
