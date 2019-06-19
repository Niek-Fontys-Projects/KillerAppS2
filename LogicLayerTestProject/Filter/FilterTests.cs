using LogicLayer.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayerTestProject.FilterTest
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void FilterTest()
        {
            IWordFilter filter = new WordFilter(new List<string>() { "test", "another" });
            Assert.AreEqual("This is *** unit***. Test", filter.Filter("This is another unittest. Test"));
        }
    }
}
