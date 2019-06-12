using System;
using System.Collections.Generic;
using DataLayer.DataBase.QueryBuilder;

namespace DataLayer.DataBase
{
    internal interface IDataBase
    {
        IQueryBuilder QueryBuilder { get; }

        bool ExecuteInsertQuery();
        IEnumerable<T> ExecuteSelectQuery<T>(Type _instanciatedObjectType);
    }
}