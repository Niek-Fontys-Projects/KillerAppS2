using DataAccessLayer;
using DataAccessLayer.Repository;
using DataAccessLayer.TextReader;
using LogicLayer.Filter;
using LogicLayer.Hasher;
using LogicLayer.LogInValidator;
using LogicLayer.MailSender;
using Microsoft.Extensions.Configuration;
using ModelLayer.Structural_Interfaces;

namespace ServiceLayer
{
    internal class ServiceLayerBuilder
    {
        private IConfiguration configuration;
        private DataLayerBuilder dataBuilder;
        public ServiceLayerBuilder(IConfiguration _configuration)
        {
            configuration = _configuration;
            dataBuilder = new DataLayerBuilder(_configuration);
        }

        #region Repository
        private ICategoryRepo GetCategoryRepo()
        {
            return dataBuilder.GetCategoryRepo();
        }

        private IRiddleRepo GetRiddleRepo()
        {
            return dataBuilder.GetRiddleRepo();
        }

        private IUserRepo GetUserRepo()
        {
            return dataBuilder.GetUserRepo();
        }
        #endregion

        internal IUserValidator GetUserValidator()
        {
            return new Validator();
        }

        internal ISaltHasher GetHasher()
        {
            return new SaltHasher();
        }

        internal IMailSender GetMailSender()
        {
            return new SMTPSender();
        }
        
        internal string BlackListLocation;
        internal IWordFilter GetWordFilter()
        {
            ITextAccessor textAccessor = GetTextAccessor();
            return new WordFilter(textAccessor.GetLines(BlackListLocation));
        }

        private ITextAccessor GetTextAccessor()
        {
            return new TextAccessor();
        }
    }
}
