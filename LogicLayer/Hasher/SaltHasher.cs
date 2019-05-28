using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LogicLayer.Hasher
{
    public class SaltHasher : ISaltHasher
    {
        public SaltHasher()
        {

        }

        public IObjectPair<string, string> HashNewSalt(string _passWord) // nieuw wachtwoord hashen
        {
            string salt = GenerateRandomSalt(); // maak een random salt aan
            return new ObjectPair<string, string>(Hash(_passWord, salt), salt);
        }

        public string Hash(string _passWord, string _salt) // ingevulde wachtwoord checken
        {
            string total = _passWord + _salt; 
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(total); 
            byte[] hash = SHA256.Create().ComputeHash(textData);
            return BitConverter.ToString(hash);
        }

        private string GenerateRandomSalt()
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider(); // aanmaken van random bytes
            byte[] randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
