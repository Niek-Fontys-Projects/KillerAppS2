using DataLayer.DataBase;
using DataLayer.DataBase.SyntaxMaker;
using DataLayer.DataLogger;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    internal static class Factory
    {
        #region DataBase
        internal static string ConnectionString;
        internal static IReadOnlyDictionary<Type, string> ColumnPrefixes;
        internal static IDataBase GetDataBase()
        {
            return new DataBase(GetDbConnection(), GetSyntaxMaker(), GetDataAdapter(), GetDataBaseErrorLogger());
        }

        internal static IDbDataAdapter GetDataAdapter()
        {
            return new MySqlDataAdapter();
        }

        internal static ISyntaxMaker GetSyntaxMaker()
        {
            return new MySQLSyntaxMaker(ColumnPrefixes);
        }

        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        #endregion

        #region ErrorLog
        internal static string ErrorLogLocation;

        internal static IDataBaseErrorLogger GetDataBaseErrorLogger()
        {
            return new JSonLogger(ErrorLogLocation);
        }
        #endregion
    }
}
