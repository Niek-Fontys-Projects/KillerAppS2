using DataAccessLayer.TextReader;
using DataLayer.DataBase;
using DataLayer.DataBase.QueryBuilder;
using DataLayer.DataBase.SyntaxMaker;
using DataLayer.DataLogger;
using Microsoft.Extensions.Configuration;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class DataLayerBuilder
    {
        IConfiguration configuration;

        public DataLayerBuilder(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        #region DataBase
        private IDataBase GetDataBase()
        {
            return new DataBase(GetDbConnection(), GetQueryBuilder(), GetDataAdapter(), GetDataBaseErrorLogger());
        }

        private IDbDataAdapter GetDataAdapter()
        {
            return new MySqlDataAdapter();
        }

        private IQueryBuilderWithQuery GetQueryBuilder()
        {
            return new QueryBuilder(GetSyntaxMaker());
        }

        private ISyntaxMaker GetSyntaxMaker()
        {
            return new MySQLSyntaxMaker(new Dictionary<Type, string>()
            {
                { typeof(IUserWithPassWord), configuration["DataLayer:DataBaseColumns:User"]    },
                { typeof(IMessage)         , configuration["DataLayer:DataBaseColumns:Message"] }
            });
        }

        private IDbConnection GetDbConnection()
        {
            return new MySqlConnection(configuration["DataLayer:ConnectionString"]);
        }
        #endregion

        #region FileReaders
        private IDataBaseErrorLogger GetDataBaseErrorLogger()
        {
            return new JSonLogger(configuration["DataLayer:DataErrorLog"]);
        }

        public ITextAccessor GetTextAccessor()
        {
            return new TextAccessor();
        }
        #endregion

        #region Repository
        public 
        #endregion
    }
}
