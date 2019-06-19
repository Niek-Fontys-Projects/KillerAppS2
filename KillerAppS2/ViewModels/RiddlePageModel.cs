using ServiceLayer.ViewModels.InputViewModels;
using ServiceLayer.ViewModels.OutputViewModels;

namespace KillerAppS2.ViewModel
{ 
    public class RiddlePageModel
    {
        private AddMessageModel post;
        private RiddlesResultModel get;
        public RiddlePageModel()
        {
            post = new AddMessageModel();
            get = new RiddlesResultModel();
        }
        public AddMessageModel Post { get; set; }
        public RiddlesResultModel Get { get; internal set; }
    }
}
