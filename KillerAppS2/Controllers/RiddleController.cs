﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Handlers;
using ServiceLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class RiddleController : Controller
    {
        RiddleHandler riddleHandler;

        public RiddleController()
        {
            riddleHandler = new RiddleHandler();
        }

        public IActionResult Category(string _categoryName)
        {
            return View("RiddlePage", riddleHandler.GetRiddlesFromCategory(_categoryName));
        }

        [HttpPost]
        public IActionResult PostMessage(RiddlePageModel _rpm)
        {
            return View("RiddlePage", riddleHandler.PostMessage(_rpm));
        }
    }
}