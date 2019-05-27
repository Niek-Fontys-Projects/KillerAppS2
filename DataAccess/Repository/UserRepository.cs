using DataLayer.DataBase.QueryBuilder;
using DataLayer.DataBase.SyntaxMaker;
using ModelLayer.General_Interfaces;
using ModelLayer.General_Models;
using ModelLayer.Structural_Interfaces;
using System.Linq;

namespace DataLayer.Repository
{
    public class UserRepository : ILogInRepo
    {
        DataBase.DataBase dataBase;
        public UserRepository()
        {
            dataBase = new DataBase.DataBase(new QueryBuilder(new MySQLSyntaxMaker()) , "server=localhost; database=s2riddle#2; Uid=root; password=;");
        }

        public IUserWithPassWord GetUserByUserName(string _userName)
        {
            dataBase.QueryBuilder.GetUserByUserName("test1");
            return dataBase.ExecuteStoredProcedure<IUserWithPassWord>(typeof(User)).DefaultIfEmpty(null).FirstOrDefault();
        }
    }
}
