using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        public IActionResult LogIn(LogInModel _lim)
        {
            if (ModelState.IsValid)
            {
                if (userHandler.ValidateLoginAttempt(_lim))
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