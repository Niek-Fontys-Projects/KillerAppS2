using ServiceLayer.ViewModels.OutputViewModels;

namespace PresentationLayer.ViewModels
{
    public class StartPageModel
    {
        public CategoriesModel Categories { get; set; }

        public RiddlesResultModel Riddles { get; set; }
    }
}
