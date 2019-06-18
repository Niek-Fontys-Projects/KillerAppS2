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
            DataLayerBuilder.ConnectionString = configuration["DataLayer:ConnectionString"];
            DataLayerBuilder.ColumnPrefixes = new Dictionary<Type, string>()
            {
                { typeof(IUserWithPassWord), configuration["DataLayer:DataBaseColumns:User"]    },
                { typeof(IMessage)         , configuration["DataLayer:DataBaseColumns:Message"] }
            };
            DataLayerBuilder.ErrorLogLocation = configuration["DataLayer:DataErrorLog"];
        }
    }
}
