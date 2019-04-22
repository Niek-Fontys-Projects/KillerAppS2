using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class QueryBuilder : IQueryBuilderWithQuery
    {
        private string query;
        private ISyntaxMaker syntaxMaker;

        public QueryBuilder()
        {
            query = String.Empty;
        }

        public string Query
        {
            get { return query; }
        }

        public void ClearQuery()
        {
            query = String.Empty; ;
        }

        public void Insert(IAnnouncement _announcement)
        {
            syntaxMaker.InsertPreFix(Query, typeof(IAnnouncement));
            query += syntaxMaker.Insert(_announcement);
        }

        public void Insert(IUserWithPassWord _user)
        {
            syntaxMaker.InsertPreFix(Query, typeof(IUserWithPassWord));
            query += syntaxMaker.Insert(_user);
        }

        public void Insert(IRating _rating)
        {
            syntaxMaker.InsertPreFix(Query, typeof(IRating));
            query += syntaxMaker.Insert(_rating);
        }

        public void Insert(IMessage _message)
        {
            syntaxMaker.InsertPreFix(Query, typeof(IMessage));
            query += syntaxMaker.Insert(_message);
        }
    }
}
