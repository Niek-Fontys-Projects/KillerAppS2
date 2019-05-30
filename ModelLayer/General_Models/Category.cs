using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.General_Models
{
    public class Category : ICategory
    {
        private string categoryName;
        public Category()
        {
            categoryName = String.Empty;
        }
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
    }
}
