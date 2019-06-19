using IntegrationTests.ReplacementClasses;
using LogicLayer.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Handlers;
using ServiceLayer.ViewModels.OutputViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTests
{
    [TestClass]
    public class RiddleHandlerIntegration
    {
        [TestMethod]
        public void HandlerTest()
        {
            RiddleHandler handler = new RiddleHandler(new TestRiddleRepo(), new WordFilter(new List<string>(){ "word", "unit", "test" }));
            RiddlesResultModel model = handler.GetRiddlesFromCategory("");
            Assert.AreEqual("creator", model.Riddles.First().User.UserName);
            Assert.AreEqual("Riddle1", model.Riddles.First().RiddleName);
            Assert.AreEqual(1, model.Riddles.First().Categories.Count());
            Assert.AreEqual(1, model.Riddles.First().Messages.Count());
        }
    }
}
