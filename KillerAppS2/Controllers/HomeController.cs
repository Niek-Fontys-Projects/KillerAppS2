using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ViewModels;
using ServiceLayer;
using ServiceLayer.Handlers;

namespace KillerAppS2.Controllers
{
    public class HomeController : Controller
    {
        private CategoryHandler categoryHandler;
        private RiddleHandler riddleHandler;

        public HomeController(ServiceLayerBuilder serviceLayerBuilder)
        {
            categoryHandler = serviceLayerBuilder.GetCategoryHandler();
            riddleHandler = serviceLayerBuilder.GetRiddleHandler();
        }
        
        public IActionResult Index()
        {
            return View("StartPage", new StartPageModel() { Categories = categoryHandler.GetAllCategories(), Riddles = riddleHandler.Get5UnsolvedRiddles() });
        }
    }
}