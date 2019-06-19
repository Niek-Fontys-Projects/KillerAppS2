using DataLayer.DataBase;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    internal class RiddleRepository : IRiddleRepo
    {
        private IDataBase dataBase;
        internal RiddleRepository(IDataBase _dataBase)
        {
            dataBase = _dataBase;
        }

        private void FillRiddleSubObjects(IRiddle _riddle)
        {
            object[] param = new object[1] { _riddle.RiddleName };
            dataBase.QueryBuilder.StoredProcedure("GetCategoryNamesByRiddleName", param);
            _riddle.Categories = dataBase.ExecuteSelectQuery<ICategory>(typeof(Category));
            dataBase.QueryBuilder.StoredProcedure("GetMessagesByRiddleName", param);
            _riddle.Messages = dataBase.ExecuteSelectQuery<IMessage>(typeof(Message));
            foreach (IMessage message in _riddle.Messages)
            {
                param = new object[2] { message.MessageContent, message.Time };
                dataBase.QueryBuilder.StoredProcedure("GetUserOfMessage", param);
                message.User = dataBase.ExecuteSelectQuery<IUser>(typeof(User)).First();
            }
        }
        public IEnumerable<IRiddle> GetRiddlesByCategory(string _categoryName)
        {
            object[] param = new object[1] { _categoryName };
            dataBase.QueryBuilder.StoredProcedure("GetRiddleByCategoryName", param);
            IEnumerable<IRiddle> riddles = dataBase.ExecuteSelectQuery<IRiddle>(typeof(Riddle));
            foreach (IRiddle riddle in riddles)
            {
                FillRiddleSubObjects(riddle);
            }
            return riddles;
        }

        public void PostMessage(string _userID, string _riddleName, string _message)
        {
            object[] param = new object[3] { _userID, _riddleName, _message };
            dataBase.QueryBuilder.StoredProcedure("InsertMessage", param);
            dataBase.ExecuteInsertQuery();
        }

        public IEnumerable<IRiddle> GetUnsolvedRiddles()
        {

            object[] param = new object[0];
            dataBase.QueryBuilder.StoredProcedure("GetUnsolvedRiddles", param);
            IEnumerable<IRiddle> riddles = dataBase.ExecuteSelectQuery<IRiddle>(typeof(Riddle));
            foreach (IRiddle riddle in riddles)
            {
                FillRiddleSubObjects(riddle);
            }
            return riddles;
        }
    }
}
