using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ViewModels.OutputViewModels
{
    public class CategoriesModel
    {
        public IEnumerable<ICategory> Categories { get; internal set; }
    }
}
