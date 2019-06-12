using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public static class DataAccess
    {
        public static void DataAccessConfig(this IConfiguration configuration)
        {
            Factory.ConnectionString = configuration["DataLayer:ConnectionString"];
        }
    }
}
