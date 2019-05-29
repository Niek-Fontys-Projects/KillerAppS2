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
                userHandler.ValidateLoginAttempt(_lim);
                {
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