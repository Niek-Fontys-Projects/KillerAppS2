using DataLayer.DataBase.SyntaxMaker;
using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataBase.QueryBuilder
{
    internal class QueryBuilder : IQueryBuilderWithQuery
    {
        private string query;
        private ISyntaxMaker syntaxMaker;

        internal QueryBuilder(ISyntaxMaker _syntaxMaker)
        {
            syntaxMaker = _syntaxMaker;
            query = String.Empty;
        }

        public string Query
        {
            get { return query; }
        }

        private void ClearQuery()
        {
            query = String.Empty; ;
        }
        //old
        //public void Insert(IAnnouncement _announcement)
        //{
        //    syntaxMaker.InsertPreFix(Query, typeof(IAnnouncement));
        //    query += syntaxMaker.Insert(_announcement);
        //}

        //public void Insert(IUserWithPassWord _user)
        //{
        //    syntaxMaker.InsertPreFix(Query, typeof(IUserWithPassWord));
        //    query += syntaxMaker.Insert(_user);
        //}

        //public void Insert(IRating _rating)
        //{
        //    syntaxMaker.InsertPreFix(Query, typeof(IRating));
        //    query += syntaxMaker.Insert(_rating);
        //}

        //public void Insert(IMessage _message)
        //{
        //    syntaxMaker.InsertPreFix(Query, typeof(IMessage));
        //    query += syntaxMaker.Insert(_message);
        //}

        private string ParamsToString(object[] _parameters)
        {
            string parameters = String.Empty;
            foreach (object p in _parameters)
            {
                parameters = syntaxMaker.ToParameter(parameters, p);
            }
            return parameters;
        }

        public void StoredProcedure(string _procedureName, object[] _parameters)
        {
            ClearQuery();
            query += syntaxMaker.StoredProcedure(_procedureName, ParamsToString(_parameters));
        }

        public void Insert(Type _type, object[] _parameters)
        {
            ClearQuery();
            query += syntaxMaker.Insert(_type, ParamsToString(_parameters));
        }
    }
}
