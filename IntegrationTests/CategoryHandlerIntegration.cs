using IntegrationTests.ReplacementClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.Handlers;
using ServiceLayer.ViewModels.OutputViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests
{
    [TestClass]
    public class CategoryHandlerIntegration
    {
        [TestMethod]
        public void GetCategories()
        {
            CategoryHandler handler = new CategoryHandler(new TestCatRepo());
            CategoriesModel model = handler.GetAllCategories();
            int count = 1;
            foreach(ICategory cat in model.Categories)
            {
                Assert.AreEqual("test" + count, cat.CategoryName);
                count++;
            }
            Assert.AreEqual(5, count);
        }
    }
}
