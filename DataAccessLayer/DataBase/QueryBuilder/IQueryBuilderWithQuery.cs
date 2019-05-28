using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataBase.QueryBuilder
{
    internal interface IQueryBuilderWithQuery : IQueryBuilder
    {
        string Query { get; }
    }
}
