using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IQueryBuilderWithQuery : IQueryBuilder
    {
        string Query { get; }
    }
}
