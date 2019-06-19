using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.ReplacementClasses
{
    public class TestRiddleRepo : IRiddleRepo
    {
        public IEnumerable<IRiddle> GetRiddlesByCategory(string _categoryName)
        {
            return new List<IRiddle>()
            {
                new Riddle()
                {
                    User = new User(){UserName = "creator", Email = "creator@creator.creator", UserID = "Creatorid"},
                    RiddleName = "Riddle1",
                    RiddleContent = "Content1",
                    Answer = "Answer1",
                    Categories = new List<ICategory>(){new Category() { CategoryName = "Category1"} },
                    Messages = new List<IMessage>(){new Message() { MessageContent = "message", Time = "too damn late"} }
                }
            };
        }

        public IEnumerable<IRiddle> GetUnsolvedRiddles()
        {
            return GetRiddlesByCategory("");
        }

        public void PostMessage(string _userID, string _riddleName, string _message)
        {

        }
    }
}
