using DataLayer.DataBase.SyntaxMaker;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System.Linq;

namespace DataLayer.Repository
{
    public class UserRepository : IUserRepo
    {
        DataBase.DataBase dataBase;
        public UserRepository()
        {
            dataBase = new DataBase.DataBase("server=localhost; database=s2riddle#3; Uid=root; password=;", new MySQLSyntaxMaker());
        }

        public IUserWithPassWord GetUserByUserName(string _userName)
        {
            object[] param = new object[1] { _userName };
            dataBase.QueryBuilder.StoredProcedure("GetuserByUserName", param);
            return dataBase.ExecuteStoredProcedure<IUserWithPassWord>(typeof(User)).DefaultIfEmpty(null).FirstOrDefault();
        }

        public void AddUser(string _userName, string _mail, string _passWord, string _PassWordhash)
        {
            object[] param = new object[5] { null, _userName, _mail, _passWord, _PassWordhash};
            dataBase.QueryBuilder.Insert(typeof(IUserWithPassWord), param);
            dataBase.ExecuteInsertQuery();
        }
    }
}
