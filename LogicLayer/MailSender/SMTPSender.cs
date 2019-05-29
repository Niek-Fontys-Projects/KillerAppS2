using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace LogicLayer.MailSender
{
    public class SMTPSender : IMailSender
    {
        SmtpClient client;
        MailMessage mail;
        public SMTPSender()
        {
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("riddleform.s27@gmail.com", "#Riddler2");
            client.EnableSsl = true;
            NewMail();
        }

        public void NewMail()
        {
            mail = new MailMessage();
        }
        public void SendMail()
        {
            mail.From = new MailAddress("riddleform.s27@gmail.com");
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
