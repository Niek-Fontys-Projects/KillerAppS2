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
            dataBase = new DataBase();
        }
        public IEnumerable<IRiddle> GetRiddlesByCategory(string _categoryName)
        {
            object[] param = new object[1] { _categoryName };
            dataBase.QueryBuilder.StoredProcedure("GetRiddleByCategoryName", param);
            IEnumerable<IRiddle> riddles = dataBase.ExecuteStoredProcedure<IRiddle>(typeof(Riddle));
            foreach(IRiddle riddle in riddles)
            {
                param = new object[1] { riddle.RiddleName };
                dataBase.QueryBuilder.StoredProcedure("GetCategoryNamesByRiddleName", param);
                riddle.Categories = dataBase.ExecuteStoredProcedure<ICategory>(typeof(Category));
            }
            return riddles;
        }
    }
}
