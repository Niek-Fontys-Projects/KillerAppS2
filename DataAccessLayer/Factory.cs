using DataLayer.DataBase;
using DataLayer.DataBase.SyntaxMaker;
using DataLayer.DataLogger;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccessLayer
{
    internal static class Factory
    {
        internal static string ConnectionString;

        #region DataBase
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
            return new MySQLSyntaxMaker();
        }

        internal static IDbConnection GetDbConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        #endregion

        internal static IDataBaseErrorLogger GetDataBaseErrorLogger()
        {
            return new JSonLogger();
        }
    }
}
