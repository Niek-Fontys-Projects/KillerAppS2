using LogicLayer.Hasher;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using System.Net.Mail;

namespace LogicLayer.LogInValidator
{
    public class Validator : IUserValidator
    {
        private readonly ISaltHasher hasher;
        public Validator()
        {
            hasher = new SaltHasher();
        }

        public LogInResult ValidateUser(string _userName, string _passWord, IUserWithPassWord _user)
        {
            if (_user == null)
            {
                return LogInResult.UserName;
            }
            if (hasher.Hash(_passWord, _user.PassWordHash) != _user.PassWord)
            {
                return LogInResult.PassWord;
            }
            return LogInResult.Good;
        }

        public bool ValidateEMailAddress(string _email)
        {
            try
            {
                MailAddress mail = new MailAddress(_email);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
