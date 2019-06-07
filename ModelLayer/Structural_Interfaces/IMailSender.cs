namespace ModelLayer.Structural_Interfaces
{
    public interface IMailSender
    {
        void AddReceiver(string _address);
        void NewMail();
        void SendMail();
        void SetContent(string _content);
        void SetSubject(string _subject);
    }
}