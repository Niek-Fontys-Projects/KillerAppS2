using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Handlers;

namespace KillerAppS2.Controllers
{
    public class HomeController : Controller
    {
        private CategoryHandler categoryHandler;

        public HomeController()
        {
            categoryHandler = new CategoryHandler();
        }
        
        public IActionResult Index()
        {
            return View("StartPage", categoryHandler.GetAllCategories());
        }
    }
}