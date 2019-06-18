using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System;
using System.Security.Cryptography;

namespace LogicLayer.Hasher
{
    internal class SaltHasher : ISaltHasher
    {
        private RNGCryptoServiceProvider rngCryptoServiceProvider;
        internal SaltHasher(RNGCryptoServiceProvider _rngCryptoServiceProvider)
        {
            rngCryptoServiceProvider = _rngCryptoServiceProvider;
        }

        public IObjectPair<string, string> HashNewSalt(string _passWord)
        {
            byte[] randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            string salt = Convert.ToBase64String(randomBytes);
            return new ObjectPair<string, string>(Hash(_passWord, salt), salt);
        }

        public string Hash(string _passWord, string _salt)
        {
            string total = _passWord + _salt; 
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(total); 
            byte[] hash = SHA256.Create().ComputeHash(textData);
            return BitConverter.ToString(hash);
        }
    }
}
