using Microsoft.AspNetCore.Mvc;
using Services.BlogPosts;

namespace MVC_1.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostService blogPostService;

        public BlogController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            var response = blogPostService.GetAllAsync();
            return View(response);
        }
    }
}
