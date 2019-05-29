using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Handlers;
using ServiceLayer.InputViewModels;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private UserHandler userHandler;

        public UserController(UserHandler _userHandler)
        {
            userHandler = _userHandler;
        }

        public IActionResult AddUser(AddUserModel _aum)
        {
            if (ModelState.IsValid)
            {
                userHandler.Adduser(_aum);
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
                    HttpContext.Session.SetString("User", resultPair.Object2.UserID);
                    HttpContext.Session.SetString("UserName", resultPair.Object2.UserName);
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