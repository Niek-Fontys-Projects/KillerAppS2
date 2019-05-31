using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.General_Models
{
    public class Message : IMessage
    {
        private string userName;
        private string time;
        private string messageContent;

        public Message()
        {
            userName = String.Empty;
            time = String.Empty;
            messageContent = String.Empty;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string MessageContent
        {
            get { return messageContent; }
            set { messageContent = value; }
        }
    }
}
