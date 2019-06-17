using DataLayer.DataBase.QueryBuilder;
using DataLayer.DataBase.SyntaxMaker;
using DataLayer.DataLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataLayer.DataBase
{
    internal class DataBase : IDataBase
    {
        private IDbConnection connection;
        private IDbDataAdapter adapter;
        private IQueryBuilderWithQuery queryBuilder;
        private IDataBaseErrorLogger errorLogger;

        internal DataBase(IDbConnection _connection, IQueryBuilderWithQuery _queryBuilder, IDbDataAdapter _adapter, IDataBaseErrorLogger _errorLogger)
        {
            connection = _connection;
            queryBuilder = _queryBuilder;
            adapter = _adapter;
            errorLogger = _errorLogger;
        }

        public IQueryBuilder QueryBuilder
        {
            get { return queryBuilder; }
        }

        public bool ExecuteInsertQuery()
        {
            try
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText = queryBuilder.Query;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Task.Run(() => errorLogger.LogDataBaseError(queryBuilder.Query, e.Message, DateTime.Now.ToString()));
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public IEnumerable<T> ExecuteSelectQuery<T>(Type _instanciatedObjectType)
        {
            DataSet set = new DataSet();
            IList<T> objects = new List<T>();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = queryBuilder.Query;
            adapter.SelectCommand = command;
            try
            {
                connection.Open();
                adapter.Fill(set);
            }
            catch (Exception e)
            {
                Task.Run(() => errorLogger.LogDataBaseError(queryBuilder.Query, e.Message, DateTime.Now.ToString()));
            }
            finally
            {
                connection.Close();
            }
            if (set.Tables.Count > 0)
            {
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    T newObject = (T)Activator.CreateInstance(_instanciatedObjectType);
                    PropertyInfo[] properties = newObject.GetType().GetProperties();
                    object[] values = row.ItemArray;
                    for (int i = 0; i < values.Length; i++)
                    {
                        properties.Where(x => x.Name == set.Tables[0].Columns[i].ColumnName).First().SetValue(newObject, values[i]);
                    }
                    objects.Add(newObject);
                }
            }
            return objects;
        }
    }
}
