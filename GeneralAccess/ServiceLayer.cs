using DataAccessLayer;
using LogicLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public static class ServiceLayer
    {
        public static void ServiceLayerConfig(this IConfiguration configuration)
        {
            configuration.DataAccessConfig();
            configuration.LogicLayerConfig();
        }
    }
}
