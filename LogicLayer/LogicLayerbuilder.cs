using LogicLayer.Filter;
using LogicLayer.Hasher;
using LogicLayer.LogInValidator;
using LogicLayer.MailSender;
using Microsoft.Extensions.Configuration;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace LogicLayer
{
    public class LogicLayerBuilder
    {
        private IConfiguration configuration;

        public LogicLayerBuilder(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        #region SaltHasher
        private RNGCryptoServiceProvider GetCryptoServiceProvider()
        {
            return new RNGCryptoServiceProvider();
        }

        public ISaltHasher GetSaltHasher()
        {
            return new SaltHasher(GetCryptoServiceProvider());
        }
        #endregion

        #region SMTP
        private MailAddress GetFromAddress()
        {
            return new MailAddress(configuration["LogicLayer:MailSettings:FromMail"]);
        }

        private SmtpClient GetSmtpClient()
        {
            return new SmtpClient(configuration["LogicLayer:MailSettings:Client"]);
        }

        public IMailSender GetMailSender()
        {
            return new SMTPSender(GetSmtpClient(), GetFromAddress());
        }
        #endregion

        public IWordFilter GetWordFilter(IEnumerable<string> _blackList)
        {
            return new WordFilter(_blackList);
        }

        public IUserValidator GetUserValidator()
        {
            return new Validator();
        }
    }
}
