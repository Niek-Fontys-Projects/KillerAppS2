using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public IActionResult LogIn(ServiceLayer.InputViewModels.LogInModel _lim)
        {
            if (ModelState.IsValid)
            {
                if (userHandler.ValidateLoginAttempt(_lim))
                {
                    return View();
                }
            }
            return View();
            //errorview
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}