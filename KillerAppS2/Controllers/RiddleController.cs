using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KillerAppS2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Handlers;
using ServiceLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class RiddleController : Controller
    {
        private RiddleHandler riddleHandler;
        private CategoryHandler categoryHandler;

        public RiddleController(ServiceLayerBuilder serviceLayerBuilder)
        {
            riddleHandler = serviceLayerBuilder.GetRiddleHandler();
            categoryHandler = serviceLayerBuilder.GetCategoryHandler();
        }

        public IActionResult Category(string _categoryName)
        {
            return View("RiddlePage", new RiddlePageModel() { Get = riddleHandler.GetRiddlesFromCategory(_categoryName), Categories = categoryHandler.GetAllCategories() });
        }

        [HttpPost]
        public IActionResult PostMessage(RiddlePageModel _rpm)
        {
            if (ModelState.IsValid)
            {
                riddleHandler.PostMessage(_rpm.Post);
                return Redirect(Url.Action("Index", "Home"));
            }
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}