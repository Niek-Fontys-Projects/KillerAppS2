using DataLayer.DataBase;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class CategoryRepository
    {
        IDataBase dataBase;

        public CategoryRepository()
        {
            dataBase = new DataBase();
        }

        public IEnumerable<ICategory> GetAllCategories()
        {
            object[] param = new object[0];
            dataBase.QueryBuilder.StoredProcedure("GetAllCategories", param);
            return dataBase.ExecuteStoredProcedure<ICategory>(typeof(Category));
        }
    }
}
