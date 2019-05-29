using System;
using System.Collections.Generic;
using DataLayer.DataBase.QueryBuilder;

namespace DataLayer.DataBase
{
    public interface IDataBase
    {
        IQueryBuilder QueryBuilder { get; }

        bool ExecuteInsertQuery();
        IEnumerable<T> ExecuteStoredProcedure<T>(Type _instanciatedObjectType);
    }
}