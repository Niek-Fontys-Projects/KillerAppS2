using Microsoft.Extensions.Configuration;
using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public static class DataAccess
    {
        public static void DataAccessConfig(this IConfiguration configuration)
        {
            Factory.ConnectionString = configuration["DataLayer:ConnectionString"];
            Factory.ColumnPrefixes = new Dictionary<Type, string>()
            {
                { typeof(IUserWithPassWord), configuration["DataLayer:DataBaseColumns:User"]    },
                { typeof(IMessage)         , configuration["DataLayer:DataBaseColumns:Message"] }
            };
            Factory.ErrorLogLocation = configuration["DataLayer:DataErrorLog"];
        }
    }
}
