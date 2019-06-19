using DataAccessLayer;
using DataAccessLayer.Repository;
using DataAccessLayer.TextReader;
using LogicLayer;
using LogicLayer.Filter;
using LogicLayer.Hasher;
using LogicLayer.LogInValidator;
using LogicLayer.MailSender;
using Microsoft.Extensions.Configuration;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.Handlers;

namespace ServiceLayer
{
    public class ServiceLayerBuilder
    {
        private IConfiguration configuration;
        private DataLayerBuilder dataBuilder;
        private LogicLayerBuilder logicBuilder;
        public ServiceLayerBuilder(IConfiguration _configuration)
        {
            configuration = _configuration;
            dataBuilder = new DataLayerBuilder(_configuration);
            logicBuilder = new LogicLayerBuilder(_configuration);
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

        #region Logic
        private IUserValidator GetUserValidator()
        {
            return logicBuilder.GetUserValidator();
        }

        private ISaltHasher GetHasher()
        {
            return logicBuilder.GetSaltHasher();
        }

        private IMailSender GetMailSender()
        {
            return logicBuilder.GetMailSender();
        }

        private IWordFilter GetWordFilter()
        {
            ITextAccessor textAccessor = GetTextAccessor();
            return logicBuilder.GetWordFilter(textAccessor.GetLines(configuration["ServiceLayer:BlackListLocation"]));
        }

        private ITextAccessor GetTextAccessor()
        {
            return dataBuilder.GetTextAccessor();
        }
        #endregion

        #region Handlers
        public CategoryHandler GetCategoryHandler()
        {
            return new CategoryHandler(GetCategoryRepo());
        }

        public UserHandler GetUserHandler()
        {
            return new UserHandler(GetUserValidator(), GetUserRepo(), GetHasher(), GetMailSender());
        }

        public RiddleHandler GetRiddleHandler()
        {
            return new RiddleHandler(GetRiddleRepo(), GetWordFilter());
        }
        #endregion
    }
}
