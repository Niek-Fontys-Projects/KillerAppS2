using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RiddleController : Controller
    {
        public IActionResult Categorie(string _categorieName)
        {
            return View();
        }
    }
}