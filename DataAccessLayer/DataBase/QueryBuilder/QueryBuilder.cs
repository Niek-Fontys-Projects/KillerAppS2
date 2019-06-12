using DataLayer.DataBase.SyntaxMaker;
using System;

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
