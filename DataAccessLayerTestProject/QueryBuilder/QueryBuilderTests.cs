using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.DataBase.QueryBuilder;
using DataLayer.DataBase.SyntaxMaker;
using System.Collections.Generic;
using System;

namespace DataAccessLayerTestProject.QueryBuilderTest
{
    [TestClass]
    public class QueryBuilderTests
    {
        [TestMethod]
        public void QueryBuilderTest()
        {
            IQueryBuilderWithQuery queryBuilder = new QueryBuilder(new MySQLSyntaxMaker(new Dictionary<Type, string>()
            {
            { typeof(string), "string" }
             }));
            queryBuilder.Insert(typeof(string), new object[] { "test", 1 });
            Assert.AreEqual("INSERT INTO string VALUES ('test',1)", queryBuilder.Query);

            queryBuilder.StoredProcedure("procedure", new object[] { 1, "test" });
            Assert.AreEqual("Call procedure(1,'test')", queryBuilder.Query);
        }
    }
}
