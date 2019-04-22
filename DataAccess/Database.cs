using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class Database
    {
        private MySqlConnection connection;
        private IQueryBuilderWithQuery queryBuilder;
        private string connString = "server=localhost; database=s2riddle#1; Uid=root; password=;";

        public Database(IQueryBuilderWithQuery _queryBuilder)
        {
            queryBuilder = _queryBuilder;
        }

        private void OpenConnection()
        {
            connection = new MySqlConnection(connString);
        }

        public IQueryBuilder QueryBuilder
        {
            get { return queryBuilder; }
        }

        public void ExecuteQuery()
        {
            try
            {
                OpenConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = queryBuilder.Query;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
                //whoops
            }
        }

        public T ExecuteQuery<T>()
        {
            return (T)new object();
        }
    }
}
