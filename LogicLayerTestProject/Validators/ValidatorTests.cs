using LogicLayer.LogInValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayerTestProject.Validators
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidatorTest()
        {
            IUserValidator validator = new Validator();
            Assert.IsFalse(validator.ValidateEMailAddress("test"));
            Assert.IsTrue(validator.ValidateEMailAddress("test@testmail.test"));
            Assert.AreEqual(LogInResult.UserName, validator.ValidateUser("test", new User() { PassWord = "test" }));
            Assert.AreEqual(LogInResult.PassWord, validator.ValidateUser("testFault", new User() { UserName = "TestUser", PassWord = "test" }));
            Assert.AreEqual(LogInResult.Good, validator.ValidateUser("test", new User() { UserName = "TestUser", PassWord = "test" }));
        }
    }
}
