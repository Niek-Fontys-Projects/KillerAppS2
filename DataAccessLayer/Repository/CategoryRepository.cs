using DataLayer.DataBase;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Repository
{
    internal class CategoryRepository : ICategoryRepo
    {
        private IDataBase dataBase;

        internal CategoryRepository(IDataBase _dataBase)
        {
            dataBase = _dataBase;
        }

        public IEnumerable<ICategory> GetAllCategories()
        {
            object[] param = new object[0];
            dataBase.QueryBuilder.StoredProcedure("GetAllCategories", param);
            return dataBase.ExecuteSelectQuery<ICategory>(typeof(Category));
        }
    }
}
