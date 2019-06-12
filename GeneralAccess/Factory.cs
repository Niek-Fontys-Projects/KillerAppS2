using DataAccessLayer.Repository;
using LogicLayer.Hasher;
using LogicLayer.LogInValidator;
using LogicLayer.MailSender;
using ModelLayer.Structural_Interfaces;

namespace ServiceLayer
{
    internal static class Factory
    {
        #region Repository
        internal static ICategoryRepo GetCategoryRepo()
        {
            return new CategoryRepository();
        }

        internal static IRiddleRepo GetRiddleRepo()
        {
            return new RiddleRepository();
        }

        internal static IUserRepo GetUserRepo()
        {
            return new UserRepository();
        }
        #endregion

        internal static IUserValidator GetUserValidator()
        {
            return new Validator();
        }

        internal static ISaltHasher GetHasher()
        {
            return new SaltHasher();
        }

        internal static IMailSender GetMailSender()
        {
            return new SMTPSender();
        }
    }
}
