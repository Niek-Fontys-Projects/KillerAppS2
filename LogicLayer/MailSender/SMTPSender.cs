using ModelLayer.Structural_Interfaces;
using System.Net.Mail;

namespace LogicLayer.MailSender
{
    public class SMTPSender : IMailSender
    {
        private SmtpClient client;
        private MailMessage mail;
        private MailAddress fromAddress;
        public SMTPSender()
        {
            client = Factory.GetSmtpClient();
            fromAddress = Factory.GetFromAddress();
            //remove for school host
            client.Credentials = new System.Net.NetworkCredential("riddleform.s27@gmail.com", "#Riddler2");
            client.EnableSsl = true;
            //
            NewMail();
        }

        public void NewMail()
        {
            mail = Factory.GetMailMessage();
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
