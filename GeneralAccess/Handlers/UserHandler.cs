using DataLayer.Repository;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.InputViewModels;
using LogicLayer;
using LogicLayer.LogInValidator;
using LogicLayer.Hasher;

namespace ServiceLayer.Handlers
{
    public class UserHandler
    {
        private readonly ILogInValidator logInValidator;
        private readonly IUserRepo userRepo;
        private readonly ISaltHasher hasher;

        public UserHandler()//ILogInValidator _logInValidator, ILogInRepo _logInRepo)
        {
            //logInValidator = _logInValidator;
            //logInRepo = _logInRepo;
            logInValidator = new Validator();
            userRepo = new UserRepository();
            hasher = new SaltHasher();
        }

        public LogInResult ValidateLoginAttempt(LogInModel _lim)
        {
            IUserWithPassWord user = userRepo.GetUserByUserName(_lim.Username);
            return logInValidator.ValidateUser(_lim.Username, hasher.Hash(_lim.Password, user.PassWordHash), user);
        }

        public void Adduser(string _userName, string _eMail, string _passWord)
        {
            //verify email
            IObjectPair<string, string> hashAndSalt = hasher.HashNewSalt(_passWord);
            //wait for verification
            userRepo.AddUser(_userName, _eMail, hashAndSalt.Object1, hashAndSalt.Object2); //werkt
        }
    }
}
