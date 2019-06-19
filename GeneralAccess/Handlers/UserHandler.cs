using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using LogicLayer.LogInValidator;
using LogicLayer.Hasher;
using LogicLayer.MailSender;
using System.Threading.Tasks;
using ModelLayer.General_Models;
using ServiceLayer.ViewModels.InputViewModels;

namespace ServiceLayer.Handlers
{
    public class UserHandler
    {
        private readonly IUserValidator userValidator;
        private readonly IUserRepo userRepo;
        private readonly ISaltHasher hasher;
        private readonly IMailSender mailSender;

        internal UserHandler(IUserValidator _userValidator, IUserRepo _userRepo, ISaltHasher _hasher, IMailSender _mailSender)
        {
            userValidator = _userValidator;
            userRepo = _userRepo;
            hasher = _hasher;
            mailSender = _mailSender;
        }

        public IObjectPair<LogInResult, IUser> ValidateLoginAttempt(LogInModel _lim)
        {
            IUserWithPassWord user = userRepo.GetUserByUserName(_lim.Username);
            LogInResult l = userValidator.ValidateUser(hasher.Hash(_lim.Password, user.PassWordHash), user);
            return new ObjectPair<LogInResult, IUser>(l, user);
        }

        public bool Adduser(AddUserModel _aum)
        {
            if (!userValidator.ValidateEMailAddress(_aum.Email)) { return false; }
            IObjectPair<string, string> hashAndSalt = hasher.HashNewSalt(_aum.Password);
            if(!userRepo.AddUser(_aum.Username, _aum.Email, hashAndSalt.Object1, hashAndSalt.Object2)) { return false; }
            mailSender.SetSubject("Welcome to RiddleForm"); mailSender.SetContent("Your Account for RiddleForm has been created");
            mailSender.AddReceiver(_aum.Email); Task.Run(() => mailSender.SendMail());
            return true;
        }
    }
}
