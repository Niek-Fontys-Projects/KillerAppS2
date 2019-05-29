using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Handlers;
using ServiceLayer.InputViewModels;

namespace KillerAppS2.Controllers
{
    public class HomeController : Controller
    {
        private UserHandler userHandler;

        public HomeController()
        {
            userHandler = new UserHandler();
        }

        [HttpPost]
        public IActionResult Index(LogInModel _lim)
        {
            //userHandler.Adduser("Niek", "niek.sleddens@gmail.com", "Leviathan");
            //if (ModelState.IsValid)
            //{
            //    userHandler.ValidateLoginAttempt(_lim);
            //    {
            //        return View();
            //    }
            //}
            return View("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}