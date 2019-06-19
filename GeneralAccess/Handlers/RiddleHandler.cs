using ModelLayer.Structural_Interfaces;
using ServiceLayer.ViewModels.InputViewModels;
using ServiceLayer.ViewModels.OutputViewModels;

namespace ServiceLayer.Handlers
{
    public class RiddleHandler
    {
        IRiddleRepo riddleRepo;
        IWordFilter wordFilter;
        internal RiddleHandler(IRiddleRepo _riddleRepo, IWordFilter _wordFilter)
        {
            riddleRepo = _riddleRepo;
            wordFilter = _wordFilter;
        }

        public RiddlesResultModel GetRiddlesFromCategory(string _category)
        {
            return new RiddlesResultModel() { Riddles = riddleRepo.GetRiddlesByCategory(_category) };
        }

        public void PostMessage(AddMessageModel _rpm)
        {
            riddleRepo.PostMessage(_rpm.UserID, _rpm.RiddleName, wordFilter.Filter(_rpm.Message));
        }

        public RiddlesResultModel Get5UnsolvedRiddles()
        {
            return new RiddlesResultModel() { Riddles = riddleRepo.GetUnsolvedRiddles() };
        }
    }
}
