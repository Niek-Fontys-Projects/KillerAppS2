using DataLayer.Repository;
using ModelLayer.General_Interfaces;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.InputViewModels;
using LogicLayer;
using LogicLayer.LogInValidator;
using LogicLayer.Hasher;
using LogicLayer.MailSender;
using System.Threading.Tasks;

namespace ServiceLayer.Handlers
{
    public class UserHandler
    {
        private readonly IUserValidator userValidator;
        private readonly IUserRepo userRepo;
        private readonly ISaltHasher hasher;
        private readonly IMailSender mailSender;

        public UserHandler()
        {
            userValidator = new Validator();
            userRepo = new UserRepository();
            hasher = new SaltHasher();
            mailSender = new SMTPSender();
        }

        public LogInResult ValidateLoginAttempt(LogInModel _lim)
        {
            IUserWithPassWord user = userRepo.GetUserByUserName(_lim.Username);
            return userValidator.ValidateUser(_lim.Username, hasher.Hash(_lim.Password, user.PassWordHash), user);
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
