using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    interface ICategory
    {
        string CategoryName { get; }
        string ParentCategory { get; }
    }
}
