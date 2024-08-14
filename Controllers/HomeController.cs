using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MVC_1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IServiceServise _service;
        
        public HomeController(IServiceServise service)
        {
            _service = service;
        }
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var data = await _service.GetAllService();
            return View(data);
        }

        public async Task<IActionResult> CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceModel model)
        {
            var data = await _service.CreateService(model);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Edit()
        {
            return View();

        }



    }
}
