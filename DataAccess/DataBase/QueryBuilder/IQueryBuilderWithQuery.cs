using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataBase.QueryBuilder
{
    public interface IQueryBuilderWithQuery : IQueryBuilder
    {
        string Query { get; }
    }
}
