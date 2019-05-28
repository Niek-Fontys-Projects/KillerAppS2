using DataLayer.Repository;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.InputViewModels;

namespace ServiceLayer.Handlers
{
    public class UserHandler
    {
        private readonly ILogInValidator logInValidator;
        private readonly IUserRepo userRepo;

        public UserHandler()//ILogInValidator _logInValidator, ILogInRepo _logInRepo)
        {
            //logInValidator = _logInValidator;
            //logInRepo = _logInRepo;
            userRepo = new UserRepository();
        }

        public bool ValidateLoginAttempt(LogInModel _lim)
        {
            IUserWithPassWord loggedInUser = userRepo.GetUserByUserName(_lim.Username);
            //userRepo.AddUser("Niek", "Niek.Sleddens@gmail.com", "easyPass", "Nohash"); werkt
            if (logInValidator.ValidateUser(_lim.Username, _lim.Password, loggedInUser))
            {
                return true;
            }
            return false;
        }
    }
}
