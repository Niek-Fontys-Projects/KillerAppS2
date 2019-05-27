using DataLayer.DataBase.QueryBuilder;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DataLayer.DataBase
{
    public class DataBase
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private IQueryBuilderWithQuery queryBuilder;

        public DataBase(IQueryBuilderWithQuery _queryBuilder, string _connString)
        {//"server=localhost; database=s2riddle#2; Uid=root; password=;"
            connection = new MySqlConnection(_connString);
            queryBuilder = _queryBuilder;
            adapter = new MySqlDataAdapter();
        }

        public IQueryBuilder QueryBuilder
        {
            get { return queryBuilder; }
        }

        public void ExecuteInsertQuery()
        {
            try
            {
                connection.Open();
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
            catch(Exception e)
            {
                e.ToString();
                //whoops
            }
            finally
            {
                connection.Close();
            }
            foreach(DataRow row in table.Rows)
            {
                T newObject = (T)Activator.CreateInstance(_instanciatedObjectType);
                PropertyInfo[] properties = newObject.GetType().GetProperties();
                object[] values = row.ItemArray;
                for(int i = 0; i < values.Length; i++)
                {
                    properties[i].SetValue(newObject, values[i]);
                }
                objects.Add(newObject);
            }
            return objects;
        }
    }
}
