using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class BlogPostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
