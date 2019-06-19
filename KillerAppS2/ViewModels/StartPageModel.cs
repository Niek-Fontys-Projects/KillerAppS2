using ServiceLayer.ViewModels.OutputViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class StartPageModel
    {
        public CategoriesModel Categories { get; set; }

        public RiddlesResultModel Riddles { get; set; }
    }
}
