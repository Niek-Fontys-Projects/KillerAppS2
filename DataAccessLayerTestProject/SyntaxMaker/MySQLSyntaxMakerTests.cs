using DataLayer.DataBase.SyntaxMaker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataAccessLayerTestProject.SyntaxMakerTest
{
    [TestClass]
    public class MySQLSyntaxMakerTests
    {
        [TestMethod]
        public void SyntaxMakerTest()
        {
            ISyntaxMaker syntaxMaker = new MySQLSyntaxMaker(new Dictionary<Type, string>()
            {
            { typeof(string), "string" },
            {typeof(int), "int" }
             });
            Assert.AreEqual("INSERT INTO string VALUES (parameter)", syntaxMaker.Insert(typeof(string), "parameter"));
            Assert.AreEqual("INSERT INTO int VALUES (testing)", syntaxMaker.Insert(typeof(int), "testing"));
            Assert.AreEqual("Call procedure(params)", syntaxMaker.StoredProcedure("procedure", "params"));
            Assert.AreEqual("NULL", syntaxMaker.ToParameter(string.Empty, null));
            Assert.AreEqual("query,'string'", syntaxMaker.ToParameter("query", "string"));
            Assert.AreEqual("query,2", syntaxMaker.ToParameter("query", 2));
        }
    }
}
