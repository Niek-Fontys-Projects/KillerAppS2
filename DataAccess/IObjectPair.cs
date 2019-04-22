using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IObjectPair<T1, T2>
    {
        T1 Object1 { get; }
        T2 Object2 { get; }
    }
}
