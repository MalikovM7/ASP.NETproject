using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace MVC_1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IContactPostService contactPostService;
        private readonly IServiceService serviceService;


        public HomeController(IContactPostService contactPostService,
                IServiceService serviceService)
        {
            this.contactPostService = contactPostService;
            this.serviceService = serviceService;
           
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await serviceService.GetAllAsync();
        

            var vm = new HomeGetAllViewModel
            {
                Services = services
            };


            return View(vm);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string subject, string content)
        {
            var response = contactPostService.Add(name, email, subject, content);

            return Json(new
            {
                error = false,
                message = response
            });
        }



    }
}
