using IntegrationTests.ReplacementClasses;
using LogicLayer.Hasher;
using LogicLayer.LogInValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.Handlers;
using ServiceLayer.ViewModels.InputViewModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IntegrationTests
{
    [TestClass]
    public class UserHandlerIntegration
    {
        [TestMethod]
        public void UserHandlerTest()
        {
            UserHandler handler = new UserHandler(new Validator(), new TestUserRepo(), new SaltHasher(new RNGCryptoServiceProvider()), new TestMailSender());
            Assert.IsTrue(handler.Adduser(new AddUserModel()
            {
                Username = "testUser",
                Password = "passWord",
                Email = "test@test.mail"
            }));
            IObjectPair<LogInResult, IUser> logInResult = handler.ValidateLoginAttempt(new LogInModel()
            {
                Username = "testUser",
                Password = "passWord"
            });
            Assert.AreEqual(LogInResult.Good, logInResult.Object1);
            Assert.AreEqual("ID", logInResult.Object2.UserID);
        }
    }
}
