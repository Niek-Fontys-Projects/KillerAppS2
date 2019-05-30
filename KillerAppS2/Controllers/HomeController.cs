using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Handlers;

namespace KillerAppS2.Controllers
{
    public class HomeController : Controller
    {
        private UserHandler userHandler;

        public HomeController()
        {
            userHandler = new UserHandler();
        }

        //[HttpPost]
        //public IActionResult Index()
        //{
        //    //userHandler.Adduser("Niek", "niek.sleddens@gmail.com", "Leviathan");
        //    //if (ModelState.IsValid)
        //    //{
        //    //    userHandler.ValidateLoginAttempt(_lim);
        //    //    {
        //    //        return View();
        //    //    }
        //    //}
        //    return View("Index");
        //}
        public IActionResult Index()
        {
            return View("StartPage");
        }
    }
}