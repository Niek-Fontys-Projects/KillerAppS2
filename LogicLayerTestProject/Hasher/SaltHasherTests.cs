using LogicLayer.Hasher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using System.Security.Cryptography;

namespace LogicLayerTestProject.Hasher
{
    [TestClass]
    public class SaltHasherTests
    {
        [TestMethod]
        public void SaltHasherTest()
        {
            ISaltHasher hasher = new SaltHasher(new RNGCryptoServiceProvider());
            IObjectPair<string, string> hashSalt = hasher.HashNewSalt("unitTests");
            Assert.AreEqual(hashSalt.Object1, hasher.Hash("unitTests", hashSalt.Object2));
        }
    }
}
