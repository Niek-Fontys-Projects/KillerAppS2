using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using System;
using System.Collections.Generic;

namespace DataLayer.DataBase.SyntaxMaker
{
    internal class MySQLSyntaxMaker : ISyntaxMaker
    {
        private IReadOnlyDictionary<Type, string> columnPreFix;

        public MySQLSyntaxMaker(IReadOnlyDictionary<Type, string> _columnPreFix)
        {
            columnPreFix = _columnPreFix;
        }

        public string ToParameter(string _parameterString, object _objectToBeParameterized)
        {
            string syntax = _parameterString;
            if (syntax != String.Empty)
            {
                syntax += ",";
            }
            if (_objectToBeParameterized == null)
            {
                syntax += "NULL";
            }
            else if (_objectToBeParameterized.GetType() == typeof(string))
            {
                syntax += String.Format("'{0}'", _objectToBeParameterized);
            }
            else
            {
                syntax += _objectToBeParameterized;
            }
            return syntax;
        }

        public string StoredProcedure(string _procedureName, string _params)
        {
            string syntax = "Call ";
            syntax += _procedureName;
            syntax += "(";
            syntax += _params;
            return syntax + ")";
        }

        public string Insert(Type _type, string _params)
        {
            string syntax = "INSERT INTO ";
            syntax += columnPreFix[_type];
            syntax += " VALUES (";
            syntax += _params;
            return syntax + ")";
        }
    }
}
