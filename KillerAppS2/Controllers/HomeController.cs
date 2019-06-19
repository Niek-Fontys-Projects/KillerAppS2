using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Handlers;

namespace KillerAppS2.Controllers
{
    public class HomeController : Controller
    {
        private CategoryHandler categoryHandler;

        public HomeController(ServiceLayerBuilder serviceLayerBuilder)
        {
            categoryHandler = serviceLayerBuilder.GetCategoryHandler();
        }
        
        public IActionResult Index()
        {
            return View("StartPage", categoryHandler.GetAllCategories());
        }
    }
}