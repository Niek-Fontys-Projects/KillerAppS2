using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    internal class MySQLSyntaxMaker : ISyntaxMaker
    {
        private IEnumerable<IObjectPair<Type, string>> insertPreFixes;
        private string comma = ",";

        public MySQLSyntaxMaker()
        {
            insertPreFixes = new List<IObjectPair<Type, string>>() {
            new ObjectPair<Type, string>(typeof(IAnnouncement), "INSERT INTO `announcements` (`Topic`, `Content`) VALUES "),
            new ObjectPair<Type, string>(typeof(IUserWithPassWord), "INSERT INTO `user`(`UserName`, `EMail`, `PassWord`, `PassWordHash`) VALUES "),
            new ObjectPair<Type, string>(typeof(IRating), "INSERT INTO `rating`(`User`, `Riddle`, `Score`) VALUES "),
            new ObjectPair<Type, string>(typeof(IMessage), "INSERT INTO `message`(`User`, `Riddle`, `Message`) VALUES "),
            new ObjectPair<Type, string>(typeof(IAnswerSuggestion), "INSERT INTO `suggestedanswer`(`User`, `Riddle`, `Answer`) VALUES "),
            new ObjectPair<Type, string>(typeof(IRiddle), "INSERT INTO `riddle`(`UserID`, `RiddleName`, `Riddle`, `Answer`) VALUES ")};
        }

        public string InsertPreFix(string _query, Type _type)
        {
            if (_query == String.Empty)
            {
                return insertPreFixes.First(x => x.Object1 == _type).Object2;
            }
            return comma;
        }

        private string StringSyntax(string _string)
        {
            return String.Format("'{0}'", _string);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////>>>INSERTS<<<///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Insert(IAnnouncement _announcement)
        {
            string syntax = "(";
            syntax += StringSyntax(_announcement.Topic);
            syntax += comma;
            syntax += StringSyntax(_announcement.Content);
            return syntax + ")";
        }

        public string Insert(IUserWithPassWord _user)
        {
            string syntax = "(";
            syntax += StringSyntax(_user.UserName);
            syntax += comma;
            syntax += StringSyntax(_user.Email);
            syntax += comma;
            syntax += StringSyntax(_user.PassWord);
            syntax += comma;
            syntax += StringSyntax(_user.PassWordHash);
            return syntax + ")";
        }

        public string Insert(IRating _rating)
        {
            string syntax = "(";
            syntax += SelectUserID(_rating.UserName);
            syntax += comma;
            syntax += "X";
            syntax += comma;
            syntax += _rating.Score;
            return syntax + ")";
        }

        public string Insert(IMessage _message)
        {
            string syntax = "(";
            syntax += SelectUserID(_message.UserName);
            syntax += comma;
            syntax += "X";
            syntax += comma;
            syntax += StringSyntax(_message.Message);
            return syntax + ")";
        }

        public string Insert(IAnswerSuggestion _answerSuggestion)
        {
            string syntax = "(";
            syntax += SelectUserID(_answerSuggestion.UserName);
            syntax += comma;
            syntax += "X";
            syntax += comma;
            syntax += StringSyntax(_answerSuggestion.Answer);
            return syntax + ")";
        }

        public string Insert(IRiddle _riddle)
        {
            string syntax = "(";
            syntax += SelectUserID(_riddle.UserName);
            syntax += comma;
            syntax += StringSyntax(_riddle.RiddleName);
            syntax += comma;
            syntax += StringSyntax(_riddle.RiddleContent);
            syntax += comma;
            syntax += StringSyntax(_riddle.Answer);
            syntax += "X";
            return syntax + ")";
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////>>>SELECTS<<<///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private string SelectUserID(string _userName)
        {
            string syntax = "(";
            syntax += "SELECT USER.ID FROM `user` WHERE user.UserName = ";
            syntax += StringSyntax(_userName);
            return syntax + ")";
        }
    }
}
