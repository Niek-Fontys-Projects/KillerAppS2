using ModelLayer.Structural_Interfaces;
using System.Net.Mail;

namespace LogicLayer.MailSender
{
    internal class SMTPSender : IMailSender
    {
        private SmtpClient client;
        private MailMessage mail;
        private MailAddress fromAddress;
        internal SMTPSender(SmtpClient _client, MailAddress _fromAddress)
        {
            client = _client;
            fromAddress = _fromAddress;
            NewMail();
        }

        public void NewMail()
        {
            mail = new MailMessage();
        }
        public void SendMail()
        {
            mail.From = fromAddress;
            client.Send(mail);
        }

        public void SetSubject(string _subject)
        {
            mail.Subject = _subject;
        }

        public void SetContent(string _content)
        {
            mail.Body = _content;
        }

        public void AddReceiver(string _address)
        {
            mail.To.Add(_address);
        }
    }
}
