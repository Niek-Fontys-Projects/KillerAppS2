using DataAccessLayer.Repository;
using DataAccessLayer.TextReader;
using LogicLayer.Filter;
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
        
        internal static string BlackListLocation;
        internal static IWordFilter GetWordFilter()
        {
            ITextAccessor textAccessor = GetTextAccessor();
            return new WordFilter(textAccessor.GetLines(BlackListLocation));
        }

        private static ITextAccessor GetTextAccessor()
        {
            return new TextAccessor();
        }
    }
}
