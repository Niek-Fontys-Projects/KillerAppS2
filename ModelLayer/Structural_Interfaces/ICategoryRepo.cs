using ModelLayer.General_Interfaces;
using System.Collections.Generic;

namespace ModelLayer.Structural_Interfaces
{
    public interface ICategoryRepo
    {
        IEnumerable<ICategory> GetAllCategories();
    }
}
