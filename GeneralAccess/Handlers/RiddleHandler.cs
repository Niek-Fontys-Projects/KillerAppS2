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
            riddleRepo = ServiceLayerBuilder.GetRiddleRepo();
            wordFilter = ServiceLayerBuilder.GetWordFilter();
        }

        public RiddlePageModel GetRiddlesFromCategory(string _category)
        {
            return new RiddlePageModel() { Get = new RiddlesResultModel() { Riddles = riddleRepo.GetRiddlesByCategory(_category) } };
        }

        public void PostMessage(RiddlePageModel _rpm)
        {
            riddleRepo.PostMessage(_rpm.Post.UserID, _rpm.Post.RiddleName, wordFilter.Filter(_rpm.Post.Message));
        }
    }
}
