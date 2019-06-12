using DataLayer.DataLogger;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public static class DataAccessFactory
    {
        internal static IDataBaseErrorLogger GetDataBaseErrorLogger()
        {
            return new JSonLogger();
        }
    }
}
