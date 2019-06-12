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
        public RiddleHandler()
        {
            riddleRepo = Factory.GetRiddleRepo();
        }

        public RiddlePageModel GetRiddlesFromCategory(string _category)
        {
            return new RiddlePageModel() { Get = new RiddlesResultModel() { Riddles = riddleRepo.GetRiddlesByCategory(_category) } };
        }

        public RiddlePageModel PostMessage(RiddlePageModel _rpm)
        {
            //filter message
            riddleRepo.PostMessage(_rpm.Post.UserID, _rpm.Post.RiddleName, _rpm.Post.Message);
            //update affected video
            return _rpm;
        }
    }
}
