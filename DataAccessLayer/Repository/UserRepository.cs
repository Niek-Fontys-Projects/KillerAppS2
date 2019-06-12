using DataAccessLayer;
using DataLayer.DataBase;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IUserRepo
    {
        IDataBase dataBase;
        public UserRepository()
        {
            dataBase = Factory.GetDataBase();
        }

        public IUserWithPassWord GetUserByUserName(string _userName)
        {
            object[] param = new object[1] { _userName };
            dataBase.QueryBuilder.StoredProcedure("GetUserByUserName", param);
            return dataBase.ExecuteSelectQuery<IUserWithPassWord>(typeof(User)).DefaultIfEmpty(new User()).FirstOrDefault();
        }

        public bool AddUser(string _userName, string _mail, string _passWord, string _PassWordhash)
        {
            object[] param = new object[5] { null, _userName, _mail, _passWord, _PassWordhash};
            dataBase.QueryBuilder.Insert(typeof(IUserWithPassWord), param);
            return dataBase.ExecuteInsertQuery();
        }
    }
}
