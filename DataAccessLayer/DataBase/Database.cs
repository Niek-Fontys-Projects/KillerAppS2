using DataLayer.DataBase.QueryBuilder;
using DataLayer.DataBase.SyntaxMaker;
using DataLayer.DataLogger;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace DataLayer.DataBase
{
    public class DataBase : IDataBase
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private IQueryBuilderWithQuery queryBuilder;
        private IDataBaseErrorLogger errorLogger;

        public DataBase()
        {
            connection = new MySqlConnection("server=localhost; database=s2riddle#4; Uid=root; password=;");
            queryBuilder = new QueryBuilder.QueryBuilder(new MySQLSyntaxMaker());
            adapter = new MySqlDataAdapter();
            errorLogger = new JSonLogger();
        }

        public IQueryBuilder QueryBuilder
        {
            get { return queryBuilder; }
        }

        public bool ExecuteInsertQuery()
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = queryBuilder.Query;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Task.Run(() => errorLogger.LogDataBaseError(queryBuilder.Query, e.Message, e.StackTrace, DateTime.Now.ToString()));
                Type x = e.GetType();
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public IEnumerable<T> ExecuteStoredProcedure<T>(Type _instanciatedObjectType)
        {
            DataTable table = new DataTable();
            IList<T> objects = new List<T>();
            adapter.SelectCommand = new MySqlCommand(queryBuilder.Query, connection);
            try
            {
                connection.Open();
                adapter.Fill(table);
            }
            catch (Exception e)
            {
                Task.Run(() => errorLogger.LogDataBaseError(queryBuilder.Query, e.Message, e.StackTrace, DateTime.Now.ToString()));
            }
            finally
            {
                connection.Close();
            }
            foreach (DataRow row in table.Rows)
            {
                T newObject = (T)Activator.CreateInstance(_instanciatedObjectType);
                PropertyInfo[] properties = newObject.GetType().GetProperties();
                object[] values = row.ItemArray;
                for (int i = 0; i < values.Length; i++)
                {
                    properties[i].SetValue(newObject, values[i]);
                }
                objects.Add(newObject);
            }
            return objects;
        }
    }
}
