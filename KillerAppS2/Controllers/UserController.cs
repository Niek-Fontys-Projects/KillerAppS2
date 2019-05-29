using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Handlers;
using ServiceLayer.InputViewModels;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private UserHandler userHandler;

        public UserController()
        {
            userHandler = new UserHandler();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(AddUserModel _aum)
        {
            if (ModelState.IsValid)
            {
                if (userHandler.Adduser(_aum))
                {
                    return View("LogIn");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogInModel _lim)
        {
            if (ModelState.IsValid)
            {
                var resultPair = userHandler.ValidateLoginAttempt(_lim);
                if (resultPair.Object1 == ModelLayer.Structural_Interfaces.LogInResult.Good)
                {
                    HttpContext.Session.SetString("UserID", resultPair.Object2.UserID);
                    HttpContext.Session.SetString("UserName", resultPair.Object2.UserName);
                    ISession s = HttpContext.Session;
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
    }
}