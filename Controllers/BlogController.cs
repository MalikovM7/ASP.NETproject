using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostService blogPostService;

        public BlogController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult Blog()
        {
            var response = blogPostService.GetAllAsync();
            return View(response);
        }
    }
}
