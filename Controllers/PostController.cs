using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{
    public class PostController : Controller
    {

        private readonly IBlogPostService _model;

        public PostController(IBlogPostService model)
        {
            _model = model;
        }
        public IActionResult Post()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var data = await _model.GetAllPost();
            return View(data);
        }

        public async Task<IActionResult> CreatePost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(BlogPost model)
        {
            var data = await _model.CreatePost(model);
             return Json(model);
        }



    }
}
