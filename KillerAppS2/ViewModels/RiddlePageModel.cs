using ServiceLayer.ViewModels.InputViewModels;
using ServiceLayer.ViewModels.OutputViewModels;

namespace KillerAppS2.ViewModel
{ 
    public class RiddlePageModel
    {
        private CategoriesModel categories;
        private AddMessageModel post;
        private RiddlesResultModel get;
        public RiddlePageModel()
        {
            post = new AddMessageModel();
            get = new RiddlesResultModel();
            categories = new CategoriesModel();
        }
        public AddMessageModel Post { get; set; }
        public RiddlesResultModel Get { get; internal set; }
        public CategoriesModel Categories { get; internal set; }
    }
}
