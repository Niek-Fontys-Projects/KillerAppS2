using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace LogicLayer
{
    internal static class Factory
    {
        #region SaltHasher
        internal static RNGCryptoServiceProvider GetCryptoServiceProvider()
        {
            return new RNGCryptoServiceProvider();
        }
        #endregion

        #region SMTP
        internal static string FromAddress;
        internal static string SMTPClient;

        internal static MailAddress GetFromAddress()
        {
            return new MailAddress(FromAddress);
        }

        internal static SmtpClient GetSmtpClient()
        {
            return new SmtpClient(SMTPClient);
        }

        internal static MailMessage GetMailMessage()
        {
            return new MailMessage();
        }
        #endregion
    }
}
