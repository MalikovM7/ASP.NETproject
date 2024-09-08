using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IServiceService _service;
        private readonly IUserService _userService;
        public HomeController(IServiceService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
        
            return View();
        }

        //public async Task<IActionResult> CreateService()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateService(ServiceModel model)
        //{
        //    var data = await _service.CreateService(model);
        //    return RedirectToAction("Index", "Home");

        //    //return Json(model);
        //}

        [HttpGet]

        public async Task<IActionResult> GetAllUsers()
        {

            var data= await _userService.GetAll();
            return View(data);

        }


        [HttpDelete]


        public async Task<IActionResult> Remove(int id)
        {
            var data= await _userService.Remove(id);
            return RedirectToAction("Index", "Home");
        }


    

    }
}
