﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Handlers;
using ServiceLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class RiddleController : Controller
    {
        RiddleHandler riddleHandler;

        public RiddleController(ServiceLayerBuilder serviceLayerBuilder)
        {
            riddleHandler = serviceLayerBuilder.GetRiddleHandler();
        }

        public IActionResult Category(string _categoryName)
        {
            return View("RiddlePage", riddleHandler.GetRiddlesFromCategory(_categoryName));
        }

        [HttpPost]
        public IActionResult PostMessage(RiddlePageModel _rpm)
        {
            if (ModelState.IsValid)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}