﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
