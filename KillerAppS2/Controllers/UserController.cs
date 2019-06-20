using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Handlers;
using ServiceLayer.ViewModels.InputViewModels;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private CategoryHandler categoryHandler;
        private UserHandler userHandler;

        public UserController(ServiceLayerBuilder serviceLayerBuilder)
        {
            userHandler = serviceLayerBuilder.GetUserHandler();
            categoryHandler = serviceLayerBuilder.GetCategoryHandler();
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
                if (userHandler.Adduser(_aum) && _aum.PasswordRepeat == _aum.Password)
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
                    return Redirect(Url.Action("Index", "Home"));
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}