using DataAccessLayer.Repository;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.OutputViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Handlers
{
    public class RiddleHandler
    {
        IRiddleRepo riddleRepo;
        IWordFilter wordFilter;
        public RiddleHandler()
        {
            riddleRepo = Factory.GetRiddleRepo();
            wordFilter = Factory.GetWordFilter();
        }

        public RiddlePageModel GetRiddlesFromCategory(string _category)
        {
            return new RiddlePageModel() { Get = new RiddlesResultModel() { Riddles = riddleRepo.GetRiddlesByCategory(_category) } };
        }

        public RiddlePageModel PostMessage(RiddlePageModel _rpm)
        {
            riddleRepo.PostMessage(_rpm.Post.UserID, _rpm.Post.RiddleName, wordFilter.Filter(_rpm.Post.Message));
            //update affected video
            return _rpm;
        }
    }
}
