using DataLayer.Repository;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.InputViewModels;

namespace ServiceLayer.Handlers
{
    public class UserHandler
    {
        private readonly ILogInValidator logInValidator;
        private readonly ILogInRepo logInRepo;

        public UserHandler()//ILogInValidator _logInValidator, ILogInRepo _logInRepo)
        {
            //logInValidator = _logInValidator;
            //logInRepo = _logInRepo;
            logInRepo = new UserRepository();
        }
        public bool ValidateLoginAttempt(LogInModel _lim)
        {
            IUserWithPassWord loggedInUser = logInRepo.GetUserByUserName(_lim.Username);
            if (logInValidator.ValidateUser(_lim.Username, _lim.Password, loggedInUser))
            {
                return true;
            }
            return false;
        }
    }
}
