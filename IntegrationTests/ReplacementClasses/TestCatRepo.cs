using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.ReplacementClasses
{
    public class TestCatRepo : ICategoryRepo
    {
        public IEnumerable<ICategory> GetAllCategories()
        {
            return new List<ICategory>()
            {
                new Category() { CategoryName = "test1" },
                new Category() { CategoryName = "test2" },
                new Category() { CategoryName = "test3" },
                new Category() { CategoryName = "test4" }
            };
        }
    }
}
