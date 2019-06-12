using DataLayer.DataBase;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class RiddleRepository : IRiddleRepo
    {
        IDataBase dataBase;

        public RiddleRepository()
        {
            dataBase = Factory.GetDataBase();
        }
        public IEnumerable<IRiddle> GetRiddlesByCategory(string _categoryName)
        {
            object[] param = new object[1] { _categoryName };
            dataBase.QueryBuilder.StoredProcedure("GetRiddleByCategoryName", param);
            IEnumerable<IRiddle> riddles = dataBase.ExecuteSelectQuery<IRiddle>(typeof(Riddle));
            foreach(IRiddle riddle in riddles)
            {
                param = new object[1] { riddle.RiddleName };
                dataBase.QueryBuilder.StoredProcedure("GetCategoryNamesByRiddleName", param);
                riddle.Categories = dataBase.ExecuteSelectQuery<ICategory>(typeof(Category));
                dataBase.QueryBuilder.StoredProcedure("GetMessagesByRiddleName", param);
                riddle.Messages = dataBase.ExecuteSelectQuery<IMessage>(typeof(Message));
            }
            return riddles;
        }

        public void PostMessage(string _userID, string _riddleName, string _message)
        {
            object[] param = new object[3] { _userID, _riddleName, _message };
            dataBase.QueryBuilder.StoredProcedure("InsertMessage", param);
            dataBase.ExecuteInsertQuery();
        }
    }
}
