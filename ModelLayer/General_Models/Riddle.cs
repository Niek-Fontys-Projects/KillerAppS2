using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.General_Models
{
    public class Riddle : IRiddle
    {
        private IUser user;
        private string riddleName;
        private string riddleContent;
        private string answer;
        private IEnumerable<ICategory> categories;
        private IEnumerable<IMessage> messages;

        public Riddle()
        {
            user = null;
            riddleName = String.Empty;
            riddleContent = String.Empty;
            answer = String.Empty;
            categories = new List<ICategory>();
            messages = new List<IMessage>();
        }

        public IUser User
        {
            get { return user; }
            set { user = value; }
        }

        public string RiddleName
        {
            get { return riddleName; }
            set { riddleName = value; }
        }

        public string RiddleContent
        {
            get { return riddleContent; }
            set { riddleContent = value; }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public IEnumerable<ICategory> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public IEnumerable<IMessage> Messages
        {
            get { return messages; }
            set { messages = value; }
        }
    }
}
